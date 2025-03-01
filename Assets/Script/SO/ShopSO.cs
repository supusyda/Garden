using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShopSO", menuName = "ShopSO")]
public class ShopSO : ScriptableObject
{
    public List<HarvesSO> shopItems = new List<HarvesSO>();

}
