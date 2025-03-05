using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text buyTxt;

    [SerializeField] private Image itemImage;
    [SerializeField] private Button buyBtn;

    public void SetItem(HarvesSO harvestSO)
    {
        itemNameText.text = harvestSO.name;
        priceText.text = "";
        itemImage.sprite = harvestSO.sprite;
        buyTxt.text = (-harvestSO.price * harvestSO.GetBuyAmount()).ToString() + " Coin";
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() =>
        {


            harvestSO.Buy();

        });
    }

}
