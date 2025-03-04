using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Transform itemTemplate;
    [SerializeField] private Transform itemSellTemplate;
    [SerializeField] private Transform farmerBuyTemplate;
    [SerializeField] private Transform plotBuyTemplate;



    [SerializeField] private ShopSO shopSO;
    void Start()
    {
        Init();
        InitProducts();

    }
    // Update is called once per frame

    void Init()
    {
        foreach (var item in shopSO.shopItems)
        {
            switch (item)
            {
                case HarvesSO harvestSO:
                    Transform itemInSHop = Instantiate(itemTemplate, transform);
                    itemInSHop.gameObject.SetActive(true);
                    itemInSHop.GetComponent<ItemUI>().SetItem(harvestSO);
                    break;

                case FarmerSO farmerSO:
                    Transform itemInShop = Instantiate(farmerBuyTemplate, transform);
                    itemInShop.gameObject.SetActive(true);
                    itemInShop.GetComponent<FarmerBuyUI>().SetItem(farmerSO);

                    break;
                case PlotSO Plot:
                    Transform plotInShop = Instantiate(plotBuyTemplate, transform);
                    plotInShop.gameObject.SetActive(true);
                    plotInShop.GetComponent<PlotBuyUI>().SetItem(Plot);

                    break;
            }


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
