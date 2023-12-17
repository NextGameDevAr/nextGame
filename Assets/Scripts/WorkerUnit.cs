using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerUnit : Unit
{
    [SerializeField] public Action<bool> OnStationInteraction;


    [SerializeField] private Order item;
    [SerializeField] private Transform itemPosition;


    internal override void Interact()
    {
        HandlerStationInteraction();

        HandlerOrderCounterInteraction();

        HandlerGarbageBinInteraction();
    }

    private void HandlerStationInteraction()
    {
        if (interactiveObject is Station)
        {
            if (HasItem())
            {
                OnInteractionComplete();
                return;
            }
            Station station = (Station)interactiveObject;
            station.Interact(new StationInteractiveParams(OnStationInteractionComplete));
            OnStationInteraction?.Invoke(true);
        }
    }

    private void HandlerOrderCounterInteraction()
    {
        if (interactiveObject is OrderCounter)
        {
            OrderCounter orderCounter = (OrderCounter)interactiveObject;
            if (HasItem())
            {
                DeliverOrderCounterInteractiveParams orderCounterParams = new DeliverOrderCounterInteractiveParams(this.item, DeilverOrder);
                orderCounter.Interact(orderCounterParams);
            }
            else
            {
                OrderCounterInteractiveParams orderCounterParams = new OrderCounterInteractiveParams(OnInteractionComplete);
                orderCounter.Interact(orderCounterParams);
            }

        }
    }

    private void HandlerGarbageBinInteraction()
    {
        if (interactiveObject is GarbageBin)
        {
            if (!HasItem())
            {
                OnInteractionComplete();
                return;
            }
            GarbageBin garbageBin = interactiveObject as GarbageBin;
            garbageBin.Interact(new GargbageBinInteractiveParams(OnInteractionComplete, this.item));
        }
    }

    public void DeilverOrder(bool orderDelivered)
    {
        if(orderDelivered)
        {
            Destroy(item.gameObject); // TODO: change this with a function that give back this item to the pool
        } else {
           
            //Client dont want this order
        }
        OnInteractionComplete();
    }

    private bool HasItem()
    {
        return item!= null;
    }
    private void OnStationInteractionComplete(Order item)
    {
        this.item = item;
        item.SetParent(itemPosition);
        OnStationInteraction?.Invoke(false);
        OnInteractionComplete();
    }
}
