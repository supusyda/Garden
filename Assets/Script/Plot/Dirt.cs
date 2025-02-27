using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private HarvestThing harvestThing;

    void Awake()
    {
        harvestThing = GetComponentInChildren<HarvestThing>();
    }



}
