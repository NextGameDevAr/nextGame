using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerUnit : Unit
{
    [SerializeField] private Order item;
    [SerializeField] private Transform itemPosition;

    internal override void Interact()
    {
        StationInteraction();

        OrderCounterInteraction();

        GarbageBinInteraction();
    }

    private void StationInteraction()
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
        }
    }

    private void OrderCounterInteraction()
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

    private void GarbageBinInteraction()
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
        OnInteractionComplete();
    }
}
