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
    [SerializeField] private DeliveredOrderVisual deliveredOrderVisual;

    private OrderSO currentOrder;

    public void MakeAnOrder(Action onOrderComplete)
    {
        currentOrder = OrderSystem.Instance.GetAnOrder();
        visual.ShowOrder(currentOrder.item.sprite);
        onOrderComplete?.Invoke();
    }

    public void DeliverOrder(Order item)
    {
        visual.HideOrder();
        currentOrder = null;
        ClientUnitSystem.Instance.AddOrderCounterAsAvailable(this);
        currentClient.LeaveOrderCounter();
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

    public bool HasClient()
    {
        return currentClient != null;
    }

    public void Interact(BaseInteractiveParams interactiveParams)
    {
        if(interactiveParams is DeliverOrderCounterInteractiveParams)
        {
            DeliverOrder(interactiveParams as DeliverOrderCounterInteractiveParams);
        }
        if(interactiveParams is OrderCounterInteractiveParams)
        {
            TakeAnOrder(interactiveParams as OrderCounterInteractiveParams);
        }
    }

    private void DeliverOrder(DeliverOrderCounterInteractiveParams deliverParams)
    {
        bool canDeilverOrder = CanDeliverOrder(deliverParams.deliveryItem);
        if (canDeilverOrder)
        {
            DeliverOrder(deliverParams.deliveryItem);
        }
        deliveredOrderVisual.PlayDeliverAnimation(canDeilverOrder);
        deliverParams.onInteractionComplete(canDeilverOrder);
    }

    private void TakeAnOrder(OrderCounterInteractiveParams orderParams)
    {
        if(HasClient())
        {
            MakeAnOrder(orderParams.onInteractionComplete);
        }
        else
        {
            orderParams.onInteractionComplete?.Invoke();
        }
    }

    private bool CanDeliverOrder(Order item)
    {
        bool canDeliver = HasAnOrder() && currentOrder.id == item.GetId();
        
        return canDeliver;
    }

    private bool HasAnOrder()
    {
        return currentOrder != null;
    }
}

public class OrderCounterInteractiveParams : BaseInteractiveParams
{
    public Action onInteractionComplete;

    public OrderCounterInteractiveParams(Action onInteractionComplete)
    {
        this.onInteractionComplete = onInteractionComplete;
    }
}

public class DeliverOrderCounterInteractiveParams : BaseInteractiveParams
{
    public Order deliveryItem;
    public Action<bool> onInteractionComplete;

    public DeliverOrderCounterInteractiveParams(Order deliveryItem, Action<bool> onInteractionComplete)
    {
        this.deliveryItem = deliveryItem;
        this.onInteractionComplete = onInteractionComplete;
    }
}
