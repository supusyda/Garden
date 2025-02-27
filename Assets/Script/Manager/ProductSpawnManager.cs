using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawnManager : Spawner
{
    public static ProductSpawnManager instance;
    protected override void OnEnable()
    {
        base.OnEnable();
        ProductSpawnManager.instance = this;
    }
    private Transform SpawnProduct(Vector3 SpawnPos, string particelName)
    {
        Transform spawnObj = base.SpawnThing(SpawnPos, Quaternion.identity, particelName);
        spawnObj.gameObject.SetActive(true);
        return spawnObj;

    }
    public void ReturnToPool(Transform obj)
    {
        obj.gameObject.SetActive(false);
    }
    public void OnSpawnHarvestProduct(Component sender, object data)
    {

        // Debug.Log("OnSpawnHarvestProduct" + data as ProductSO);
        Product spawnedProduct = SpawnProduct(sender.transform.position, "ProductPrefab").GetComponent<Product>();
        spawnedProduct.SetProduct(data as ProductSO);

    }
}
