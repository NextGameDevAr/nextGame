using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] internal MoveAction moveAction;
    [SerializeField] internal Transform itemPosition;
    [SerializeField] internal IInteractive interactiveObject;
    [SerializeField] internal bool canMove;

    private void Awake()
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

    private void Interact()
    {
        interactiveObject.Interact(OnInteractComplete);
    }

    private void OnInteractComplete()
    {
        canMove = true;
        interactiveObject = null;
    }
}
