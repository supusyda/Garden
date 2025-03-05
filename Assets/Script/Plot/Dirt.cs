using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Dirt : MonoBehaviour, IInteract
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private HarvestThing harvestThing;
    [SerializeField] private Transform model;
    public int productCount = 0;
    private List<Product> productsOnThisPlot = new();

    [Header("Events")]
    [SerializeField] private Event OnSetThingOnPlot;


    [Header("Bool")]
    public bool HasFarmerWorkOn = false;
    public bool IsUnlocked = false;
    public bool IsOccupied = false;






    void Awake()
    {
        harvestThing = GetComponentInChildren<HarvestThing>();
    }
    public void SetProductOnThisPlot(Product product)
    {
        productsOnThisPlot.Add(product);
    }
    public void OnDecompose()
    {


        productsOnThisPlot.Clear();
        productCount = 0;
        IsOccupied = false;
        // if (_autoHarvestCoroutine != null)
        //     StopCoroutine(_autoHarvestCoroutine);


    }

    public void AutoHarvestProductStart()
    {
        if (productsOnThisPlot.Count <= 0) return;
        Product product = PopLast(productsOnThisPlot);
        product.HarvestProduct();
    }
    // public void AutoPutThingOnDirtStart()
    // {
    //     PutThingOnDirt(ResourceManager.instance.GetIndexRemainThingToPutOnDirt());
    // }
    public bool HasProduct()
    {
        return productsOnThisPlot.Count > 0;
    }

    private T PopLast<T>(List<T> list)
    {
        if (list.Count == 0) return default; // Return null if list is empty

        T last = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return last;
    }
    public void SetIsUnlock(bool isUnlock)
    {
        if (!isUnlock)
        {
            // Debug.Log(DirtManager.instance.LockDirtColor);
            model.GetComponent<SpriteRenderer>().color = DirtManager.instance.LockDirtColor;
        }
        else
        {
            // Debug.Log(DirtManager.instance.UnlockDirtColor);
            model.GetComponent<SpriteRenderer>().color = DirtManager.instance.UnlockDirtColor;
        }
        this.IsUnlocked = isUnlock;
    }
    public bool CanNotBePutOnDirt()
    {
        return IsUnlocked == false || IsOccupied == true || HasFarmerWorkOn == true;
    }
    public void PutThingOnDirt(HarvestResource harvestResource)
    {
        IsOccupied = true;
        harvestThing.SetPlant(harvestResource.harvestThing);

        OnSetThingOnPlot?.Raise(this, harvestResource);

    }
    public void Interact()
    {
        if (!IsUnlocked || !ResourceManager.instance.GetThingToPutOnPlot().harvestThing || IsOccupied) return;
        if (ResourceManager.instance.GetThingToPutOnPlot().amount <= 0) return;
        ResourceManager.instance.GetThingToPutOnPlot().amount--;
        PutThingOnDirt(ResourceManager.instance.GetThingToPutOnPlot());


    }
}
