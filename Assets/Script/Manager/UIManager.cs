using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]

    [SerializeField] Transform shopPanel;
    [SerializeField] Transform gameOverPanel;




    /// 

    public void ShowShopPanel()
    {
        shopPanel.GetComponent<IUITransis>().Show();
        ;
    }
    public void HideShopPanel()
    {
        shopPanel.GetComponent<IUITransis>().Hide();
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.GetComponent<IUITransis>().Show();
    }

    //     public void OnEnable()
    //     {
    //         EventManager.Instance.AddListener(EventType.UpdateProductUI, OnUpdateProductUI);
    //     }

    //     public void OnDisable()
    //     {
    //         EventManager.Instance.RemoveListener(EventType.UpdateProductUI, OnUpdateProductUI);
    // }

}

