using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HarvestType
{
    Fruit,
    Animal,
    None
}

[CreateAssetMenu(fileName = "Harvest", menuName = "Harvest/HarvestSO")]

public class HarvesSO : ScriptableObject, IShopItem
{
    // Start is called before the first frame update
    public string harvestObjName;
    public int harvestMaximumAmount;
    public int harvestAmount;

    public float harvestTimeMinutes;
    public HarvestType harvestType;
    public ProductSO harvestProduct;
    public Sprite sprite;
    public int price;


    public int Cost => price;

    public void Buy()
    {
        if (ResourceManager.instance.GetCoin() >= price * GetBuyAmount())
            ResourceManager.instance.BuyHarvest(this, GetBuyAmount());
    }
    public int GetBuyAmount()
    {

        switch (harvestType)
        {
            case HarvestType.Fruit:
                return 10;
            case HarvestType.Animal:
                return 1;
            default:
                return 0;
        }
    }
}

