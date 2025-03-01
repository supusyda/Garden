using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductSellUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private TMP_Text buyTxt;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button buyBtn;

    public void SetItem(ProductResource productResource)
    {
        itemNameText.text = productResource.product.name;
        amountText.text = productResource.amount.ToString();
        itemImage.sprite = productResource.product.productSprite;
        buyTxt.text = "+ " + (productResource.product.productPrice).ToString() + " Coin";
        buyBtn.onClick.AddListener(() =>
        {
            if (productResource.amount > 0)
            {
                ResourceManager.instance.AddCoin(productResource.product.productPrice);
            }
        });
    }
}
