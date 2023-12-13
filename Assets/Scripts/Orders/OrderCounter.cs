using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCounter : MonoBehaviour
{
    [SerializeField] private OrderCounterVisual visual;
    [SerializeField] private Transform clientSpot;

    private OrderSO currentOrder;
    private Action OnOrderComplete;

    public void MakeAnOrder(Action onOrderComplete)
    {
        OnOrderComplete = onOrderComplete;
        currentOrder = OrderSystem.Instance.GetAnOrder();
        visual.ShowOrder(currentOrder.item.sprite);
        StartCoroutine(Wait3Seconds());
    }

    private IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(5);
        DeliverOrder(currentOrder);
    }

    public void DeliverOrder(OrderSO order)
    {
        visual.HideOrder();
        currentOrder = null;
        OnOrderComplete?.Invoke();
        ClientUnitSystem.Instance.AddOrderCounterAsAvailable(this);
    }

    public Vector3 GetClientSpot()
    {
        return clientSpot.position;
    }
}
