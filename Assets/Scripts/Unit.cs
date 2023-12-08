using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{

    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private Action OnReachPosition;
    [SerializeField] private Item currentItem;
    [SerializeField] private Transform itemPosition;

    public void Update()
    {
        if (finalPosition == transform.position) return;

        if(Vector3.Distance(transform.position, finalPosition) > 0.05f)
        {
            transform.LookAt(finalPosition);
            Vector3 moveDirection = (finalPosition - transform.position).normalized;
            float moveSpeed = 4;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

        } else
        {
            OnReachPosition?.Invoke();
            transform.position = finalPosition;
        }

    }

    public void SetItem(Item item)
    {
        currentItem = item;
        item.SetParent(itemPosition);
    }

    public void Move(Vector3 finalPosition, Action onReachPosition)
    {
        OnReachPosition = onReachPosition;
        this.finalPosition = finalPosition;
    }
}
