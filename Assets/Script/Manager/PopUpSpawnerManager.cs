using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpSpawnerManager : Spawner
{
    // Start is called before the first frame update
    [DoNotSerialize] public string POPUP = "PopUp";

    // [Header("Events")]
    public static PopUpSpawnerManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();

    }

    public void SpawnPopup(Vector3 spawnPos, int amount, Sprite sprite)
    {
        Transform spawnObj = base.SpawnThing(spawnPos, Quaternion.identity, POPUP);
        PopUp popUp = spawnObj.GetComponent<PopUp>();
        popUp.SetPopUp(amount.ToString(), sprite);
        spawnObj.gameObject.SetActive(true);
    }
    public void OnHarvestPopUp(Component sender, object data)
    {
        // Debug.Log("OnSpawnHarvestProduct" + data as ProductSO);
        Vector3 spawnPos = new Vector3(sender.transform.position.x, sender.transform.position.y, 0);

        // spawnPos.z = -1;// to make sure the product is in front of the dirt object 
        if (data is ProductSO product)
        {
            SpawnPopup(spawnPos, 1, product.productSprite);

        }

    }

}
