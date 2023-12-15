using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] internal MoveAction moveAction;
    [SerializeField] internal IInteractive interactiveObject;
    [SerializeField] internal bool canMove;

    internal void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        canMove = true;
    }
    public void Move(IInteractive interactiveObject)
    {
        if (canMove)
        {
            canMove = false;
            this.interactiveObject = interactiveObject;
            moveAction.Move(interactiveObject.GetUnitSpotPosition(), Interact);
        }
    }

    internal abstract void Interact();
    

    internal void OnInteractionComplete()
    {
        canMove = true;
        interactiveObject = null;
    }
}
