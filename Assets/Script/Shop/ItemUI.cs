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
    [SerializeField] private Image itemImage;
    public void SetItem(string itemName, int price, Sprite sprite)
    {
        itemNameText.text = itemName;
        priceText.text = price.ToString();
        itemImage.sprite = sprite;
    }

}
