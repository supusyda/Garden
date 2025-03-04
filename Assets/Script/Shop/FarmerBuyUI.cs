using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmerBuyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text currentLevelTxt;
    [SerializeField] private TMP_Text buyTxt;

    [SerializeField] private Image itemImage;
    [SerializeField] private Button buyBtn;

    /// 
    public void SetItem(FarmerSO farmerSO)
    {
        itemNameText.text = farmerSO.name;
        currentLevelTxt.text = "lv: 1";
        itemImage.sprite = farmerSO.farmerImage;
        buyTxt.text = (-farmerSO.buyCost).ToString() + " Coin";
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() =>
        {
            farmerSO.Buy();

        });
    }
}
