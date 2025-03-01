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
        priceText.text = harvestSO.price.ToString();
        itemImage.sprite = harvestSO.sprite;
        buyTxt.text = (-harvestSO.price).ToString() + " Coin";
        buyBtn.onClick.AddListener(() =>
        {
            if (ResourceManager.instance.GetCoin() >= harvestSO.price)
            {

                ResourceManager.instance.BuyHarvest(harvestSO, 1);

            }
        });
    }

}
