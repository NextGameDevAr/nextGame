using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private Action OnReachPosition;
    [SerializeField] private bool canMove;

    public void Update()
    {
        if (!canMove) return;
        if (Vector3.Distance(transform.position, finalPosition) > 0.05f)
        {
            transform.LookAt(finalPosition);
            Vector3 moveDirection = (finalPosition - transform.position).normalized;
            float moveSpeed = 4;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

        }
        else
        {
            canMove = false;
            transform.position = finalPosition;

            OnReachPosition?.Invoke();
        }

    }
    public void Move(Vector3 finalPosition, Action onReachPosition)
    {
        canMove = true;
        OnReachPosition = onReachPosition;
        this.finalPosition = finalPosition;
    }

    public bool IsWalking()
    {
        return canMove;
    }
}
