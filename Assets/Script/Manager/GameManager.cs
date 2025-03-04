using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;



    // [Header("Events")]
    // [SerializeField] private Event onUpdateUI;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // public void AddTomato(int count)
    // {
    //     tomatoCount += count;

    // }
    // public void onHarvesProduct(Component sender, object data)
    // {
    //     if (data is ProductSO productTypeSO)
    //     {
    //         int newData = 0;
    //         switch (productTypeSO.productType)
    //         {
    //             case ProductType.Tomato:
    //                 AddTomato(1);
    //                 newData = tomatoCount;
    //                 break;
    //             default:
    //                 Debug.Log("Unknown ProductType");
    //                 break;
    //         }

    //         object sendData = (productTypeSO.productType, newData);
    //         onUpdateUI?.Raise(this, sendData);
    //     }
    //     else
    //     {
    //         Debug.LogError("Invalid data type passed to onHarvestProduct");
    //     }
    // }

}
