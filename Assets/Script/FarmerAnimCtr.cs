using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerAnimCtr : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;


    private static readonly Dictionary<FarmerState, int> animationHashes = new()
    {
        { FarmerState.Idle, Animator.StringToHash(FarmerState.Idle.ToString()) },

        { FarmerState.Working, Animator.StringToHash(FarmerState.Working.ToString()) }

    };
    [SerializeField] private FarmerState _currentAnimatorState;






    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void Start()
    {


    }



    public void ChangeAnimatorState(FarmerState newState)
    {
        if (newState == _currentAnimatorState) return;
        switch (newState)
        {
            case FarmerState.Idle:
                SmothTransistion(GetHashForState(FarmerState.Idle));

                break;
            case FarmerState.Working:
                SmothTransistion(GetHashForState(FarmerState.Working));

                break;
        }
        _currentAnimatorState = newState;
    }
    public void SmothTransistion(int newHashAnim)
    {
        // animator.CrossFade(newHashAnim, 0, 0);
        animator.Play(newHashAnim);
    }
    /// 
    /// 
    public static int GetHashForState(FarmerState state)
    {
        // Debug.Log(state);
        return animationHashes[state];
    }
    bool IsAnimationFinished(int animHash)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 0 is the base layer
        return stateInfo.shortNameHash == animHash && stateInfo.normalizedTime >= 1f;
    }
}
