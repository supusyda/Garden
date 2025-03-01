using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestDopDownUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Reference")]
    [SerializeField] private Transform harvestThingTemplate;
    [Header("Events")]
    [SerializeField] private Event onSuccessfulBuy;


    private Dictionary<HarvestResource, HarvestItemUI> harvestItemUIDictionary = new Dictionary<HarvestResource, HarvestItemUI>();

    void OnEnable()
    {
        onSuccessfulBuy.Register(OnSuccesBuy);
    }
    void OnDisable()
    {
        onSuccessfulBuy.Unregister(OnSuccesBuy);
    }
    void Start()
    {
        Init();
    }

    private void Init()
    {
        List<HarvestResource> harvestResources = ResourceManager.instance.GetHarvest();
        foreach (HarvestResource harvestResource in harvestResources)
        {
            Transform harvestThing = Instantiate(harvestThingTemplate, transform);
            harvestThing.gameObject.SetActive(true);
            harvestThing.GetComponent<HarvestItemUI>().SetHarvest(harvestResource.harvestThing.sprite, harvestResource.amount);
            harvestItemUIDictionary.Add(harvestResource, harvestThing.GetComponent<HarvestItemUI>());
        }


    }
    /// <summary>
    /// Update the UI of the harvest item that matches the given HarvesSO.
    /// </summary>
    /// <param name="harvesSO">The harvest item to update.</param>
    /// 
    // 
    // pr/// 
    public void UpdateHarvestItemUI(HarvestResource dictionKey)
    {

        // Try to get the HarvestItemUI that matches the given HarvestResource
        if (harvestItemUIDictionary.ContainsKey(dictionKey))
        {
            Debug.Log("22222");

            // If we found a match, set the harvest item's sprite and amount
            harvestItemUIDictionary[dictionKey].SetHarvest(dictionKey.harvestThing.sprite, dictionKey.amount);

        }
    }
    private void OnSuccesBuy(Component sender, object data)
    {
        if (data is HarvestResource harvestResource)
        {
            Debug.Log("GO heree" + harvestResource.harvestThing.name + " " + harvestResource.amount);
            UpdateHarvestItemUI(harvestResource);
        }
    }
}
