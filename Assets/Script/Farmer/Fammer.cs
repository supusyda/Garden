using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FarmerState
{
    Idle,
    Working
}
public class Fammer : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Reference")]
    public FarmerSO farmerSO;
    private FarmerAnimCtr _farmerAnimCtr;
    private Dirt currentDirtIsWorkingOn;
    [SerializeField] private Transform model;
    [Header("State")]

    public FarmerState farmerState = FarmerState.Idle;
    [Header("Parameters")]
    [SerializeField] private int currentLevel = 1;

    private Vector2 startPos;

    public void SetFarmer(FarmerSO farmerSO)
    {
        this.farmerSO = farmerSO;
        model.GetComponent<SpriteRenderer>().sprite = farmerSO.farmerImage;
    }
    void Awake()
    {
        _farmerAnimCtr = GetComponentInChildren<FarmerAnimCtr>();
    }
    void Start()
    {
        startPos = transform.position;

        StartCoroutine(StartWorking());
    }
    public void SetState(FarmerState farmerState)
    {
        if (this.farmerState == farmerState) return;
        switch (farmerState)

        {
            case FarmerState.Idle:

                break;
            case FarmerState.Working:

                break;


            default: break;
        }
        this.farmerState = farmerState;
        _farmerAnimCtr.ChangeAnimatorState(farmerState);
    }
    IEnumerator StartWorking()
    {
        while (true)
        {
            Dirt harvestingDirt = DirtManager.instance.GetRandDirtHasProp();
            if (harvestingDirt == null)
            {
                SetState(FarmerState.Idle);
                transform.position = startPos;

                yield return new WaitForSeconds(1);
                continue;
            }
            harvestingDirt.HasFarmerWorkOn = true;
            SetState(FarmerState.Working);
            while (harvestingDirt.HasProduct())
            {
                transform.position = harvestingDirt.transform.position;

                // time for work
                yield return new WaitForSeconds(GetWorkingTime());
                harvestingDirt.AutoHarvestProductStart();

            }
            harvestingDirt.HasFarmerWorkOn = false;

            // wait for a while before start again

        }
    }
    private float GetWorkingTime()
    {
        return farmerSO.timeDoneHarvestInSecond - currentLevel * ((farmerSO.percentIncreaseEachUpgrade * farmerSO.timeDoneHarvestInSecond) / 100);
    }






}
