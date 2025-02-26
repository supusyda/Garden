using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HarvestType
{
    Fruit,
    Animal,
    None
}
[CreateAssetMenu(fileName = "Harvest", menuName = "Harvest/HarvestSO")]

public class HarvesSO : ScriptableObject
{
    // Start is called before the first frame update
    public string harvestObjName;
    public int harvestMaximumAmount;
    public int harvestAmount;

    public float harvestTimeMinutes;
    public HarvestType harvestType;
    public Transform harvestProductPrefab;
    public Sprite sprite;

}

