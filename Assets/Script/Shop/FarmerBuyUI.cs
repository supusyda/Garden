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
        currentLevelTxt.text = "Amount: " + GetAmountTxt();
        itemImage.sprite = farmerSO.farmerImage;
        buyTxt.text = (-farmerSO.buyCost).ToString() + " Coin";
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() =>
        {
            farmerSO.Buy();
            currentLevelTxt.text = "Amount: " + GetAmountTxt();
        });
    }
    public string GetAmountTxt()
    {
        return FarmerManager.Instance.GetFarmerCount() >= FarmerManager.Instance.MAX_FARMER_COUNT ? "MAX" : FarmerManager.Instance.GetFarmerCount().ToString();
    }
}
