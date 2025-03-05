using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private readonly int TARGET_COIN = 1000000;

    [Header("Events ")]

    public Event onUpdateUIDropDown;
    public Event onUpdateProductUI;
    public Event onOnCoinChange;
    public Event onGameOver;



    [Header("Data")]
    [SerializeField] private HarvestResource seletedThingToPutOnPlot;
    [SerializeField] private int ThingToPutOnPlotIndex;
    [SerializeField]
    private List<HarvestResource> harvestResources = new List<HarvestResource>();//change to dictionary
    [SerializeField]
    private List<ProductResource> productResources = new List<ProductResource>();//change to dictionary
    [SerializeField]
    private int coin = 100;

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
        onOnCoinChange?.Raise(instance, coin);
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
        AddCoin(-harvesSO.price * amount);
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
                harvestResources[i].amount += amount;

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
        coin += (int)amount;
        onOnCoinChange?.Raise(instance, coin);
        if (coin >= TARGET_COIN) onGameOver?.Raise(instance, null);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCoin(1000000);
        }
    }
    public void SetThingToPutOnPlot(HarvesSO harvesSO)
    {
        for (int i = 0; i < harvestResources.Count; i++)
        {
            if (harvestResources[i].harvestThing == harvesSO)
            {
                ThingToPutOnPlotIndex = i;
                return;
            }
        }

    }
    public HarvestResource GetThingToPutOnPlot()
    {
        return harvestResources[ThingToPutOnPlotIndex];
    }
    public HarvestResource GetIndexRemainThingToPutOnDirt()
    {
        //find index of harvestResources that amount > 0
        int i = harvestResources.FindIndex(h => h.amount > 0);
        if (i == -1) return null;
        harvestResources[i].amount -= 1;

        return harvestResources[i];
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
            // const int reduceAmount = -1;
            // HarvestResource resource = AddHarvestAmount(GetThingToPutOnPlot().harvestThing, reduceAmount);
            // harvestResources[ThingToPutOnPlotIndex] = new HarvestResource { harvestThing = GetThingToPutOnPlot().harvestThing, amount = GetThingToPutOnPlot().amount + reduceAmount };
            // harvestResources.FirstOrDefault(h => h.harvestThing == harvestResource.harvestThing).amount += reduceAmount;
            onUpdateUIDropDown?.Raise(instance, harvestResource);

        }
    }

}
[Serializable]
public class HarvestResource
{
    public HarvesSO harvestThing;
    public int amount;


}
[Serializable]
public struct ProductResource
{
    public ProductSO product;
    public int amount;
}
