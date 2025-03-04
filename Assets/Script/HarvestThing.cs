using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HarvestThing : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] protected HarvesSO harvesSO;
    [SerializeField] protected Transform plantModel;
    [SerializeField] protected Dirt dirt;
    [Header("Events")]
    [SerializeField] protected Event onSpawnedProduct;
    [SerializeField] protected Event onDecompose;


    public static float timeMultiplier = 1;

    // public int currentAmount = 0;
    protected int TIME_BEFORE_DECOMPOSE_IN_MINUTE = 60;

    Coroutine _harvestCoroutine;


    void Start()
    {
        dirt = GetComponentInParent<Dirt>();
    }




    public virtual void SetPlant(HarvesSO harvesSO)
    {
        // if (!dirt.IsUnlocked) return;


        this.harvesSO = harvesSO;
        plantModel.GetComponent<SpriteRenderer>().sprite = harvesSO ? harvesSO.sprite : null;

        if (harvesSO == null) return;
        Harvest();
    }

    protected virtual void Harvest()
    {


        if (_harvestCoroutine != null)
        {
            StopCoroutine(_harvestCoroutine);
        }

        float timeSpawnProduct = harvesSO.harvestTimeMinutes * 60;
        _harvestCoroutine = StartCoroutine(HarvestCoroutineInSec());
    }

    private IEnumerator HarvestCoroutineInSec(float time = .4f)
    {
        while (dirt.productCount < harvesSO.harvestMaximumAmount)
        {
            yield return new WaitForSeconds(time * timeMultiplier);
            dirt.productCount++;

            //todo: spawn the product
            onSpawnedProduct.Raise(this, harvesSO.harvestProduct);

        }
        // yield return new WaitForSeconds(TIME_BEFORE_DECOMPOSE_IN_MINUTE * 60*timeMultiplier);
        yield return new WaitForSeconds(1);

        Decompose();


    }
    private void Decompose()
    {
        onDecompose.Raise(this, null);


        dirt.OnDecompose();

        SetPlant(null);
    }


#if UNITY_EDITOR
    // void OnValidate()
    // {
    //     if (!Application.isPlaying)
    //     {
    //         // Safe to execute only in the editor
    //         SetPlant(harvesSO);
    //     }
    // }



#endif
}
