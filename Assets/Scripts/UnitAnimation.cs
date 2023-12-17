using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAnimation : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] internal Animator animator;
    [SerializeField] private MoveAction moveAction;

    internal void Awake()
    {
        if(animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    internal void Update()
    {
        HandlerWalkingAnimation();
    }

    private void HandlerWalkingAnimation()
    {
        animator.SetBool(IS_WALKING, moveAction.IsWalking());
    }

}
