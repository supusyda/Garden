using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInDropdownUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Image sprite;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Button button;



    public void SetHarvest(Sprite sprite, int amount, Action onClickAction = null)
    {
        this.sprite.sprite = sprite;
        amountText.text = amount.ToString();
        button.onClick?.RemoveAllListeners();
        button.onClick.AddListener(() => { onClickAction?.Invoke(); });
    }
}
