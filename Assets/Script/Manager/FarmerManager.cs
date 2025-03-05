using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerManager : Spawner
{
    // Start is called before the first frame update

    public static FarmerManager Instance;

    public readonly int MAX_FARMER_COUNT = 8;

    private int _fammerCount = 0;
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
    public Transform SpawnFarmer(Vector3 spawnPos, Quaternion direction, string prefabName)
    {
        _fammerCount++;
        return base.SpawnThing(GetStartPosOfFarmer(), direction, prefabName);
    }
    Vector2 GetStartPosOfFarmer()
    {
        return new Vector2(-2.5f + _fammerCount * 0.7f, 3);
    }
    public int GetFarmerCount() => _fammerCount;



}
