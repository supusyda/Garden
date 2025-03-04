using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlotBuyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text buyTxt;

    [SerializeField] private Image itemImage;
    [SerializeField] private Button buyBtn;

    public void SetItem(PlotSO plotData)
    {
        itemNameText.text = plotData.name;
        priceText.text = plotData.BuyPrice.ToString();
        itemImage.sprite = null;
        buyTxt.text = (-plotData.BuyPrice).ToString() + " Coin";
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() =>
        {
            if (ResourceManager.instance.GetCoin() >= plotData.BuyPrice)
            {
                plotData.Buy();
            }
        });
    }
}
