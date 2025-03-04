using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShopSO", menuName = "ShopSO")]
public class ShopSO : ScriptableObject
{
    [SerializeReference]
    public List<ScriptableObject> shopItems = new();
    public List<FarmerSO> FarmerShopItem = new List<FarmerSO>();


}
