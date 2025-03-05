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
    [SerializeField] protected Event onBeginCountdown;



    public static float Level = 1;

    // public int currentAmount = 0;
    protected int TIME_BEFORE_DECOMPOSE_IN_MINUTE = 1;

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

        float timeSpawnProduct = GetHarvestTime();
        _harvestCoroutine = StartCoroutine(HarvestCoroutineInSec(timeSpawnProduct));
    }

    /// <summary>
    /// Coroutine to handle the harvesting process over time. It waits for a specified interval
    /// before spawning products and eventually triggers decomposition.
    /// </summary>
    /// <param name="time">The base time interval in seconds for product spawn.</param>
    private IEnumerator HarvestCoroutineInSec(float time)
    {
        // Wait time for spawning a product, adjusted by a time multiplier
        var waitForSpawnInterval = new WaitForSeconds(time);
        // Wait time before triggering decomposition
        var waitForDecomposeInterval = new WaitForSeconds(TIME_BEFORE_DECOMPOSE_IN_MINUTE * 60);

        // Loop until the product count reaches the maximum harvest amount
        while (dirt.productCount < harvesSO.harvestMaximumAmount)
        {
            // Create countdown data with current position and adjusted time
            var harvestCountdownData = new OnBeginCountdownParamData
            {
                Position = transform.position,
                Time = (int)(time)
            };
            // Raise the countdown event
            onBeginCountdown.Raise(this, harvestCountdownData);

            // Wait for the spawn interval
            yield return waitForSpawnInterval;
            // Increment the product count
            dirt.productCount++;

            // Raise the event for the spawned product
            onSpawnedProduct.Raise(this, harvesSO.harvestProduct);
        }
        var countdownData = new OnBeginCountdownParamData
        {
            Position = transform.position,
            Time = (int)(TIME_BEFORE_DECOMPOSE_IN_MINUTE * 60)
        };
        // Raise the countdown event
        onBeginCountdown.Raise(this, countdownData);
        // Wait for the decomposition interval
        yield return waitForDecomposeInterval;
        // Trigger decomposition
        Decompose();
    }
    private void Decompose()
    {
        onDecompose.Raise(this, null);


        dirt.OnDecompose();

        SetPlant(null);
    }
    private float GetHarvestTime()
    {
        float baseTime = harvesSO.harvestTimeMinutes * 60;
        float reductionPerLevel = baseTime * 0.1f * (Level - 1); // 10% reduction per level
        Debug.Log(baseTime - reductionPerLevel);
        return Mathf.Max(baseTime - reductionPerLevel, 1f); // Ensure it doesn't go below 1 second
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
