using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private HarvestThing harvestThing;

    [Header("Events")]

    private int _dirtIndex;

    void Awake()
    {
        harvestThing = GetComponentInChildren<HarvestThing>();
    }




}
