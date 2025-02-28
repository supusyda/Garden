using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Transform itemTemplate;
    [SerializeField] private List<HarvesSO> harvestList = new List<HarvesSO>();
    void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void Init()
    {
        foreach (var harvest in harvestList)
        {
            Transform item = Instantiate(itemTemplate, transform);
            item.gameObject.SetActive(true);
            item.GetComponent<ItemUI>().SetItem(harvest.name, harvest.price, harvest.sprite);

        }
    }
    // [SerializeField] private List<HarvesSO>  = new List<HarvesSO>();

}
