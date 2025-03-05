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
    [Header("Event")]
    [SerializeField] private Event OnBeginCountdown;

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
                _farmerAnimCtr.ChangeAnimatorState(FarmerState.Idle);
                break;
            case FarmerState.Working:
                _farmerAnimCtr.ChangeAnimatorState(FarmerState.Working);
                break;


            default: break;
        }
        this.farmerState = farmerState;

    }
    // IEnumerator StartWorking()
    // {
    //     while (true)
    //     {
    //         Dirt harvestingDirt = DirtManager.instance.GetRandDirtHasPropForFarmer();
    //         var timeWaitBetweenEachDirt = new WaitForSeconds(1);
    //         var workTime = GetWorkingTime();
    //         if (harvestingDirt == null)
    //         {
    //             SetState(FarmerState.Idle);
    //             transform.position = startPos;

    //             yield return timeWaitBetweenEachDirt;
    //             continue;
    //         }
    //         harvestingDirt.HasFarmerWorkOn = true;
    //         SetState(FarmerState.Working);

    //         while (harvestingDirt.HasProduct())// THIS DIRT STILL HAS PRODUCT
    //         {
    //             transform.position = harvestingDirt.transform.position;

    //             // time for work
    //             var countdownData = new OnBeginCountdownParamData /// SHOW COUNTDOWN
    //             {
    //                 Position = transform.position,
    //                 Time = (int)(workTime)
    //             };
    //             // Raise the countdown event
    //             OnBeginCountdown.Raise(this, countdownData);/// SHOW COUNTDOWN



    //             yield return new WaitForSeconds(workTime);
    //             harvestingDirt.AutoHarvestProductStart();// HARVEST PRODUCT

    //         }
    //         harvestingDirt.HasFarmerWorkOn = false;



    //         // wait for a while before start again

    //     }
    // }


    IEnumerator StartWorking()
    {
        while (true)
        {
            Dirt harvestingDirt = DirtManager.instance.GetRandDirtHasPropForFarmer();
            var timeWaitBetweenEachDirt = new WaitForSeconds(1);
            // var workTime = GetWorkingTime();

            if (harvestingDirt == null)
            {
                Dirt emptyDirt = DirtManager.instance.GetEmptyDirtForFarmer();
                HarvestResource harvestResource = ResourceManager.instance.GetIndexRemainThingToPutOnDirt();

                if (emptyDirt != null && harvestResource != null)
                {

                    // HarvestResource harvestResource = ResourceManager.instance.GetIndexRemainThingToPutOnDirt();
                    // if (harvestResource == null) continue;

                    emptyDirt.HasFarmerWorkOn = true;
                    yield return StartCoroutine(SetHarvestThingOnEmptyDirt(emptyDirt, harvestResource));
                    emptyDirt.HasFarmerWorkOn = false;

                    continue;
                }

                SetState(FarmerState.Idle);
                transform.position = startPos;
                yield return timeWaitBetweenEachDirt;
                continue;
            }
            else
            {
                harvestingDirt.HasFarmerWorkOn = true;
                yield return StartCoroutine(Harvest(harvestingDirt));
            }
            harvestingDirt.HasFarmerWorkOn = false;



            // wait for a while before start again

        }
    }
    IEnumerator Harvest(Dirt dirt)
    {
        SetState(FarmerState.Working);
        while (dirt.HasProduct())
        {
            transform.position = dirt.transform.position;

            // time for work
            var countdownData = new OnBeginCountdownParamData /// SHOW COUNTDOWN
            {
                Position = transform.position,
                Time = (int)(GetWorkingTime())
            };
            // Raise the countdown event
            OnBeginCountdown.Raise(this, countdownData);/// SHOW COUNTDOWN
            yield return new WaitForSeconds(GetWorkingTime());
            dirt.AutoHarvestProductStart();


        }
    }
    IEnumerator SetHarvestThingOnEmptyDirt(Dirt dirt, HarvestResource harvestResource)
    {


        SetState(FarmerState.Working);
        transform.position = dirt.transform.position;

        // time for work
        var countdownData = new OnBeginCountdownParamData /// SHOW COUNTDOWN
        {
            Position = transform.position,
            Time = (int)(GetWorkingTime())
        };
        // Raise the countdown event
        OnBeginCountdown.Raise(this, countdownData);/// SHOW COUNTDOWN
        yield return new WaitForSeconds(GetWorkingTime());

        dirt.PutThingOnDirt(harvestResource);
        SetState(FarmerState.Idle);



    }
    private float GetWorkingTime()
    {
        return farmerSO.timeDoneHarvestInSecond - currentLevel * ((farmerSO.percentIncreaseEachUpgrade * farmerSO.timeDoneHarvestInSecond) / 100);
    }






}
