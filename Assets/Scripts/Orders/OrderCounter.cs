using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCounter : MonoBehaviour, IInteractive
{
    [SerializeField] private OrderCounterVisual visual;
    [SerializeField] private Transform clientSpot;
    [SerializeField] private Transform workerSpot;
    [SerializeField] private ClientUnit currentClient;
    [SerializeField] private Unit currentUnit;

    private OrderSO currentOrder;

    public void MakeAnOrder(Action onOrderComplete)
    {
        currentOrder = OrderSystem.Instance.GetAnOrder();
        visual.ShowOrder(currentOrder.item.sprite);
        onOrderComplete?.Invoke();
    }

    public void DeliverOrder(Action onOrderComplete)
    {
        visual.HideOrder();
        currentOrder = null;
        ClientUnitSystem.Instance.AddOrderCounterAsAvailable(this);
        currentClient.LeaveOrderCounter();
        onOrderComplete?.Invoke();
    }

    public void SetClient(ClientUnit client)
    {
        currentClient = client;
    }

    public Vector3 GetClientSpot()
    {
        return clientSpot.position;
    }

    public Vector3 GetUnitSpotPosition()
    {
        return workerSpot.position;
    }

    public void Interact(BaseInteractiveParams interactiveParams)
    {
        if(!HasAnOrder())
        {
            MakeAnOrder(interactiveParams.baseOnInteractionComplete);
        } else
        {
            DeliverOrder(interactiveParams.baseOnInteractionComplete);
        }
    }

    private bool HasAnOrder()
    {
        return currentOrder != null;
    }
}
