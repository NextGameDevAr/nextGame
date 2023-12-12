using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] internal MoveAction moveAction;
    [SerializeField] internal Transform itemPosition;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }

    public void Update()
    {
    }
    public void Move(Vector3 finalPosition, Action onReachPosition)
    {
       moveAction.Move(finalPosition, onReachPosition);
    }
}
