using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HarvestType
{
    Fruit,
    Animal,
    None
}
public enum ProductType
{
    None,
    Tomato,
    Corn,
    Milk,

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
        ResourceManager.instance.BuyHarvest(this, 1);
    }
}

