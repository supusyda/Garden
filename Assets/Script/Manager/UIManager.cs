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



    /// 
    public void SetTomatoCount(int count)
    {
        TomatoCountText.text = count.ToString();
    }


    public void OnUpdateProductUI(Component sender, object args)
    {
        Debug.Log("ASSSSSS");
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