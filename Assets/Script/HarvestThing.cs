using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestThing : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] protected HarvesSO harvesSO;
    [SerializeField] protected Transform plantModel;
    [Header("Events")]
    [SerializeField] protected Event onSpawnedProduct;
    [SerializeField] protected Event onDecompose;


    public static float timeMultiplier = 1;

    private int currentAmount;
    protected int TIME_BEFORE_DECOMPOSE_IN_MINUTE = 60;

    Coroutine _harvestCoroutine;

    public virtual void SetPlant(HarvesSO harvesSO)
    {
        this.harvesSO = harvesSO;
        plantModel.GetComponent<SpriteRenderer>().sprite = harvesSO.sprite;
    }

    protected virtual void Harvest()
    {
        Debug.Log("Harvesting");
        if (_harvestCoroutine != null)
        {
            StopCoroutine(_harvestCoroutine);
        }
        float timeSpawnProduct = harvesSO.harvestTimeMinutes * 60;
        _harvestCoroutine = StartCoroutine(HarvestCoroutineInSec());
    }

    private IEnumerator HarvestCoroutineInSec(float time = 1)
    {
        while (currentAmount < harvesSO.harvestMaximumAmount)
        {
            yield return new WaitForSeconds(time * timeMultiplier);
            currentAmount++;
            //todo: spawn the product
            onSpawnedProduct.Raise(this, harvesSO.harvestProduct);

        }
        // yield return new WaitForSeconds(TIME_BEFORE_DECOMPOSE_IN_MINUTE * 60*timeMultiplier);
        yield return new WaitForSeconds(3);

        Decompose();


    }
    private void Decompose()
    {
        Debug.Log("Decomposing");
        onDecompose.Raise(this, null);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Harvest();
        }
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (!Application.isPlaying)
        {
            // Safe to execute only in the editor
            SetPlant(harvesSO);
        }
    }

    public void Interact()
    {
        Debug.Log("CLICK ON PLANT");
        // Harvest();
    }

#endif
}
