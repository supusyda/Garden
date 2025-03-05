using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtManager : MonoBehaviour
{
    // Start is called before the first frame update\
    public static DirtManager instance;

    [Header("Parameters")]
    private int _currentDirtActive = 0;
    [SerializeField] private int initMaxDirtActive = 3;
    [SerializeField] public Color LockDirtColor = new();
    [SerializeField] public Color UnlockDirtColor = new();




    [SerializeField] List<Dirt> allDirts = new List<Dirt>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
    }


    void Init()
    {
        _currentDirtActive = 0;
        HarvestThing.Level = 1;
        Debug.Log(HarvestThing.Level);
        allDirts.Clear();
        Transform temp = transform.Find("Tilemap");
        foreach (Transform dirt in temp)
        {
            allDirts.Add(dirt.GetComponent<Dirt>());
        }
        InitDirts();
    }
    public void InitDirts()
    {
        for (int i = 0; i < allDirts.Count; i++)
        {
            if (i < initMaxDirtActive)
            {
                UnlockDirt(allDirts[i]);
                _currentDirtActive++;
            }
            else
            {
                LockDirt(allDirts[i]);
            }
        }
    }
    public void UnlockNextDirt()
    {
        if (_currentDirtActive >= allDirts.Count) return;

        allDirts[_currentDirtActive].SetIsUnlock(true);
        _currentDirtActive++;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) UnlockNextDirt();
    }
    public Dirt GetRandDirtHasPropForFarmer()
    {
        var activeDirts = allDirts.FindAll(dirt => dirt.IsUnlocked && dirt.HasProduct() && !dirt.HasFarmerWorkOn);
        return activeDirts.Count > 0 ? activeDirts[Random.Range(0, activeDirts.Count)] : null;
    }
    public Dirt GetEmptyDirtForFarmer()
    {
        var activeDirts = allDirts.FindAll(dirt => !dirt.CanNotBePutOnDirt());
        return activeDirts.Count > 0 ? activeDirts[Random.Range(0, activeDirts.Count)] : null;
    }
    void UnlockDirt(Dirt dirt)
    {
        dirt.SetIsUnlock(true);
        // _currentDirtActive++;
    }
    void LockDirt(Dirt dirt)
    {
        dirt.SetIsUnlock(false);
        // _currentDirtActive--;
    }
    public int GetAvailableDirtCount() => _currentDirtActive;
    public int GetTotalDirtCount() => allDirts.Count;
    // #if UNITY_EDITOR
    //     void OnValidate()
    //     {
    //         if (!Application.isPlaying)
    //         {
    //             // Safe to execute only in the editor
    //             Init();
    //         }
    //     }



    // #endif

}
