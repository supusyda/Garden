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
    private int currentAmount;

    Coroutine harvestCoroutine;

    public virtual void SetPlant(HarvesSO harvesSO)
    {
        this.harvesSO = harvesSO;
        // plantModel.GetComponent<SpriteRenderer>().sprite = harvesSO.sprite;
    }

    protected virtual void Harvest()
    {
        Debug.Log("Harvesting");
        if (harvestCoroutine != null)
        {
            StopCoroutine(harvestCoroutine);
        }
        harvestCoroutine = StartCoroutine(HarvestCoroutineInMinute());
    }

    private IEnumerator HarvestCoroutineInMinute(float time = 1)
    {
        while (currentAmount < harvesSO.harvestMaximumAmount)
        {
            yield return new WaitForSeconds(time * 60);
            currentAmount++;
            //todo: spawn the product
            Debug.Log(currentAmount);
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

#endif
}
