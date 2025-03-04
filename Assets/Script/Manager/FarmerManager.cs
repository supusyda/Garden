using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerManager : Spawner
{
    // Start is called before the first frame update

    public static FarmerManager Instance;
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
        return base.SpawnThing(spawnPos, direction, prefabName);
    }



}
