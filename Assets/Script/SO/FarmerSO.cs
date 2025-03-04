using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Farmer", menuName = "Farmer", order = 1)]
public class FarmerSO : ScriptableObject, IShopItem
{
    public string farmerName;
    public Sprite farmerImage;
    public int timeDoneHarvestInSecond;
    public int percentIncreaseEachUpgrade;
    public int updagradeCost;
    public int buyCost;

    public int Cost => buyCost;

    public void Buy()
    {
        if (ResourceManager.instance.GetCoin() >= buyCost)
        {
            ResourceManager.instance.AddCoin(-buyCost);
            Fammer fammer = FarmerManager.Instance.SpawnFarmer(Vector3.zero, Quaternion.identity, "Farmer").GetComponent<Fammer>();
            fammer.SetFarmer(this);
            fammer.gameObject.SetActive(true);
        }
    }
}

