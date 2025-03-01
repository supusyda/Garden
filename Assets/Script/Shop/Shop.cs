using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Transform itemTemplate;
    [SerializeField] private Transform itemSellTemplate;

    [SerializeField] private ShopSO shopSO;
    void Start()
    {
        Init();
        InitProducts();
    }
    // Update is called once per frame

    void Init()
    {
        foreach (var harvest in shopSO.shopItems)
        {
            Transform item = Instantiate(itemTemplate, transform);
            item.gameObject.SetActive(true);
            item.GetComponent<ItemUI>().SetItem(harvest);

        }
    }
    private void InitProducts()
    {
        // foreach(var harvest in shopSO.)
        foreach (var product in ResourceManager.instance.GetProduct())
        {
            Transform item = Instantiate(itemSellTemplate, transform);
            item.gameObject.SetActive(true);
            item.GetComponent<ProductSellUI>().SetItem(product);
        }
    }
    // [SerializeField] private List<HarvesSO>  = new List<HarvesSO>();

}
