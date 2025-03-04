using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    [Header("Events ")]

    public Event onUpdateUIDropDown;
    public Event onUpdateProductUI;

    [Header("Data")]
    [SerializeField] private HarvestResource seletedThingToPutOnPlot;
    [SerializeField]
    private List<HarvestResource> harvestResources = new List<HarvestResource>();
    [SerializeField]
    private List<ProductResource> productResources = new List<ProductResource>();
    [SerializeField]
    private float coin = 100;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //todo: add load data save from json
    }
    public int GetHarvestAmount(HarvesSO harvesSO)
    {
        foreach (var harvest in harvestResources)
        {
            if (harvest.harvestThing == harvesSO)
            {
                return harvest.amount;
            }
        }
        return 0;
    }

    public void BuyHarvest(HarvesSO harvesSO, int amount)
    {
        HarvestResource harvestResource = AddHarvestAmount(harvesSO, amount);
        AddCoin(-harvesSO.price);
        onUpdateUIDropDown?.Raise(instance, harvestResource);
    }
    public void SellProduct(ProductSO productSO, int amount)
    {
        Debug.Log("Amount: " + amount);
        Debug.Log("Price: " + productSO.productPrice);
        Debug.Log(productSO);
        ProductResource productResource = AddProductAmount(productSO, -amount);
        AddCoin(productResource.product.productPrice * amount);
        onUpdateProductUI?.Raise(instance, productResource);
    }
    public HarvestResource AddHarvestAmount(HarvesSO harvesSO, int amount)
    {
        for (int i = 0; i < harvestResources.Count; i++)
        {
            if (harvestResources[i].harvestThing == harvesSO)
            {
                harvestResources[i] = new HarvestResource { harvestThing = harvesSO, amount = harvestResources[i].amount + amount };
                return harvestResources[i];
            }
        }
        harvestResources.Add(new HarvestResource { harvestThing = harvesSO, amount = amount });
        return harvestResources[harvestResources.Count - 1];

    }
    public ProductResource AddProductAmount(ProductSO productSO, int amount)
    {
        int index = productResources.FindIndex(p => p.product == productSO);
        if (index != -1)
        {
            productResources[index] = new ProductResource { product = productSO, amount = productResources[index].amount + amount };
            return productResources[index];
        }
        productResources.Add(new ProductResource { product = productSO, amount = amount });
        return productResources[productResources.Count - 1];
    }
    public void AddCoin(float amount)
    {
        coin += amount;
    }
    public void SetThingToPutOnPlot(HarvesSO harvesSO)
    {
        for (int i = 0; i < harvestResources.Count; i++)
        {
            if (harvestResources[i].harvestThing == harvesSO)
            {
                seletedThingToPutOnPlot = harvestResources[i];
            }
        }

    }
    public HarvestResource GetThingToPutOnPlot()
    {
        return seletedThingToPutOnPlot;
    }
    public List<HarvestResource> GetHarvest()
    {
        return harvestResources;
    }
    public List<ProductResource> GetProduct()
    {
        return productResources;
    }
    /// 
    public int GetCoin()
    {
        return (int)coin;
    }
    public void OnHarvestProduct(Component sender, object data)
    {
        if (data is ProductSO product)
        {
            ProductResource productResource = AddProductAmount(product, 1);
            onUpdateProductUI?.Raise(instance, productResource);
        }
    }
    public void OnSetThingOnPlot(Component sender, object data)
    {
        if (data is HarvestResource harvestResource)
        {
            const int reduceAmount = -1;
            HarvestResource resource = AddHarvestAmount(GetThingToPutOnPlot().harvestThing, reduceAmount);
            SetThingToPutOnPlot(GetThingToPutOnPlot().harvestThing);

            Debug.Log("GetThingToPutOnPlot().amount: " + GetThingToPutOnPlot().amount);

            onUpdateUIDropDown?.Raise(instance, resource);

        }
    }

}
[Serializable]
public struct HarvestResource
{
    public HarvesSO harvestThing;
    public int amount;
    public override bool Equals(object obj)
    {
        if (obj is HarvestResource other)
        {
            return Equals(harvestThing, other.harvestThing);
        }
        return false;
    }
    public void SetAmount(int amount) => this.amount = amount;
    public override int GetHashCode()
    {
        return harvestThing != null ? harvestThing.GetHashCode() : 0;
    }
}
[Serializable]
public struct ProductResource
{
    public ProductSO product;
    public int amount;
}
