using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    [Header("Events ")]

    public Event onSuccessfulBuy;
    public Event onHarvest;



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
        onSuccessfulBuy?.Raise(instance, harvestResource);


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
    public void AddProductAmount(ProductSO productSO, int amount)
    {
        for (int i = 0; i < productResources.Count; i++)
        {
            if (productResources[i].product == productSO)
            {
                productResources[i] = new ProductResource { product = productSO, amount = productResources[i].amount + amount };
                return;
            }
        }
        productResources.Add(new ProductResource { product = productSO, amount = amount });
    }
    public void AddCoin(float amount)
    {
        coin += amount;
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
            AddProductAmount(product, 1);
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
