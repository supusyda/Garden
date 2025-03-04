using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestDopDownUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Reference")]
    [SerializeField] private Transform harvestThingTemplate;
    [Header("Events")]
    // [SerializeField] private Event OnUpdateDropDownUI;
    // [SerializeField] private Event OnSetThingOnPlot;



    private Dictionary<HarvestResource, ItemInDropdownUI> harvestItemUIDictionary = new Dictionary<HarvestResource, ItemInDropdownUI>();

    void OnEnable()
    {
        // OnUpdateDropDownUI.Register(OnUpdateUI);
    }
    void OnDisable()
    {
        // OnUpdateDropDownUI.Unregister(OnUpdateUI);
    }
    void Start()
    {
        Init();
    }

    /// 
    private void Init()
    {
        List<HarvestResource> harvestResources = ResourceManager.instance.GetHarvest();
        Debug.Log("CC J V");
        foreach (HarvestResource harvestResource in harvestResources)
        {
            Transform harvestThing = Instantiate(harvestThingTemplate, transform);
            harvestThing.gameObject.SetActive(true);
            harvestThing.GetComponent<ItemInDropdownUI>().SetHarvest(harvestResource.harvestThing.sprite, harvestResource.amount,
            () =>
            {
                Debug.Log("CCs");
                ResourceManager.instance.SetThingToPutOnPlot(harvestResource.harvestThing);
            }
            );
            harvestItemUIDictionary.Add(harvestResource, harvestThing.GetComponent<ItemInDropdownUI>());
        }


    }
    /// <summary>
    /// Update the UI of the harvest item that matches the given HarvesSO.
    /// </summary>
    /// <param name="harvesSO">The harvest item to update.</param>
    /// 
    // 
    // pr/// 
    public void UpdateDropdownItemUI(HarvestResource dictionKey)
    {

        // Try to get the HarvestItemUI that matches the given HarvestResource
        if (harvestItemUIDictionary.ContainsKey(dictionKey))
        {


            // If we found a match, set the harvest item's sprite and amount
            harvestItemUIDictionary[dictionKey].SetHarvest(dictionKey.harvestThing.sprite, dictionKey.amount,
            () =>
            {
                Debug.Log("CCs");
                ResourceManager.instance.SetThingToPutOnPlot(dictionKey.harvestThing);
            }
            );

        }
    }
    public void OnUpdateUI(Component sender, object data)
    {
        if (data is HarvestResource harvestResource)
        {
            UpdateDropdownItemUI(harvestResource);
        }
    }
}
