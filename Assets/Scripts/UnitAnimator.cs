using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Animator animator;
    [SerializeField] private MoveAction moveAction;

    private void Awake()
    {
        if(animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        SetIsWalking();
    }

    private void SetIsWalking()
    {
        animator.SetBool(IS_WALKING, moveAction.IsWalking());
    }

}
