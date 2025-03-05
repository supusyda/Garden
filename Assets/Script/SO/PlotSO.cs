using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Plot", menuName = "ScriptableObjects/Plot")]
public class PlotSO : ScriptableObject, IShopItem
{
    // Start is called before the first frame update
    public int UpgradePrice;
    public int BuyPrice;
    public float IncreasePercent;
    public string Name;
    public Sprite sprite;

    public int Cost => BuyPrice;

    public void Buy()
    {
        ResourceManager.instance.AddCoin(-BuyPrice);
        DirtManager.instance.UnlockNextDirt();
    }
    public void Upgrade()
    {
        if (HarvestThing.Level < 10)
        {
            HarvestThing.Level++;
            ResourceManager.instance.AddCoin(-UpgradePrice);
        }
    }
}
