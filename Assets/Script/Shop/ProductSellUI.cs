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
    [SerializeField] private Event updateProductEvent;
    private ProductSO _myProductSO;


    void OnEnable()
    {
        updateProductEvent.Register(onUpdateProduct);
    }
    void OnDisable()
    {
        updateProductEvent.Unregister(onUpdateProduct);
    }
    private void onUpdateProduct(Component sender, object data)
    {
        if (data is ProductResource productResource)
        {
            Debug.Log("onUpdateProduct");
            if (productResource.product != _myProductSO) return;
            SetItem(productResource);
        }
    }
    public void SetItem(ProductResource productResource)
    {
        _myProductSO = productResource.product;
        itemNameText.text = productResource.product.name;
        amountText.text = productResource.amount.ToString();
        itemImage.sprite = productResource.product.productSprite;
        buyTxt.text = "+ " + (productResource.product.productPrice).ToString() + " Coin";
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() =>
        {
            if (productResource.amount > 10)
            {
                ResourceManager.instance.SellProduct(productResource.product, 10);
            }
        });
    }
}
