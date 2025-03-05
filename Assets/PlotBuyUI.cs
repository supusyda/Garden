using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlotBuyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text freeDirt;
    [SerializeField] private TMP_Text buyTxt;
    [SerializeField] private TMP_Text upgradeTxt;
    [SerializeField] private TMP_Text LvlTxt;




    [SerializeField] private Image itemImage;
    [SerializeField] private Button buyBtn;
    [SerializeField] private Button upgradeBtn;


    public void SetItem(PlotSO plotData)
    {
        itemNameText.text = plotData.name;
        freeDirt.text = "Free Plot: " + GetAvailableDirtCount();
        LvlTxt.text = "Lvl: " + GetLvlTxt();
        upgradeTxt.text = (-plotData.UpgradePrice).ToString() + " Coin";

        itemImage.sprite = plotData.sprite;
        buyTxt.text = (-plotData.BuyPrice).ToString() + " Coin";
        buyBtn.onClick.RemoveAllListeners();
        upgradeBtn.onClick.RemoveAllListeners();

        buyBtn.onClick.AddListener(() =>
        {
            if (ResourceManager.instance.GetCoin() >= plotData.BuyPrice)
            {
                plotData.Buy();
                freeDirt.text = "Free Plot: " + GetAvailableDirtCount();
            }
        });
        upgradeBtn.onClick.AddListener(() =>
       {
           if (ResourceManager.instance.GetCoin() >= plotData.UpgradePrice)
           {
               plotData.Upgrade();
               LvlTxt.text = "Lvl: " + GetLvlTxt();
               upgradeTxt.text = (-plotData.UpgradePrice).ToString() + " Coin";


           }
       });
    }
    private string GetAvailableDirtCount()
    {


        return DirtManager.instance.GetAvailableDirtCount() >= DirtManager.instance.GetTotalDirtCount() ? "MAX" : DirtManager.instance.GetAvailableDirtCount().ToString();
    }
    private string GetLvlTxt()
    {


        return HarvestThing.Level >= 9 ? "MAX" : HarvestThing.Level.ToString();
    }
}
