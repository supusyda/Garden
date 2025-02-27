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
    private int currentAmount;

    Coroutine harvestCoroutine;

    public virtual void SetPlant(HarvesSO harvesSO)
    {
        this.harvesSO = harvesSO;
        plantModel.GetComponent<SpriteRenderer>().sprite = harvesSO.sprite;
    }

    protected virtual void Harvest()
    {
        Debug.Log("Harvesting");
        if (harvestCoroutine != null)
        {
            StopCoroutine(harvestCoroutine);
        }
        float timeSpawnProduct = harvesSO.harvestTimeMinutes * 60;
        harvestCoroutine = StartCoroutine(HarvestCoroutineInSec());
    }

    private IEnumerator HarvestCoroutineInSec(float time = 1)
    {
        while (currentAmount < harvesSO.harvestMaximumAmount)
        {
            yield return new WaitForSeconds(time);
            currentAmount++;
            //todo: spawn the product
            onSpawnedProduct.Raise(this, harvesSO.harvestProduct);

        }
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
