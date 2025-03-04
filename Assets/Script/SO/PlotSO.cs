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

    public int Cost => BuyPrice;

    public void Buy()
    {
        DirtManager.instance.UnlockNextDirt();
    }
}
