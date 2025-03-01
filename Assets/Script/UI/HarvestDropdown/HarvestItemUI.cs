using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HarvestItemUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Image sprite;
    [SerializeField] private TMP_Text amountText;
    [Header("Events")]
    [SerializeField] private Event OnSuccessBuy;
    public void SetHarvest(Sprite sprite, int amount)
    {
        this.sprite.sprite = sprite;
        amountText.text = amount.ToString();
    }
}
