using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] TMP_Text TomatoCountText;
    [SerializeField] Transform shopPanel;



    /// 
    public void SetTomatoCount(int count)
    {
        TomatoCountText.text = count.ToString();
    }
    public void ShowShopPanel()
    {
        shopPanel.GetComponent<IUITransis>().Show();
        ;
    }
    public void HideShopPanel()
    {
        shopPanel.GetComponent<IUITransis>().Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowShopPanel();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            HideShopPanel();
        }
    }
    //     public void OnEnable()
    //     {
    //         EventManager.Instance.AddListener(EventType.UpdateProductUI, OnUpdateProductUI);
    //     }

    //     public void OnDisable()
    //     {
    //         EventManager.Instance.RemoveListener(EventType.UpdateProductUI, OnUpdateProductUI);
    // }

    public void OnUpdateProductUI(Component sender, object args)
    {

        if (args is (ProductType productType, int amount))
        {

            int number = amount;


            switch (productType)
            {
                case ProductType.Tomato:
                    Debug.Log("Handling SomeType with number: " + number);
                    SetTomatoCount(number);
                    break;
                default:
                    Debug.Log("Unknown ProductType");
                    break;
            }
        }

        else
        {
            Debug.LogError("Invalid args format");
        }
    }
}

public struct UIUpdateData
{
    public ProductType productType;
    public int count;
}