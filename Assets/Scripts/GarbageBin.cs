using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour, IInteractive
{

    [SerializeField] private Transform workerSpot;
    public Vector3 GetUnitSpotPosition()
    {
        return workerSpot.position;
    }

    public void Interact(BaseInteractiveParams interactiveParams)
    {
        DestroyOrder(interactiveParams as GargbageBinInteractiveParams);
    }

    public void DestroyOrder(GargbageBinInteractiveParams gargbageBinParams)
    { 
        Destroy(gargbageBinParams.order.gameObject);
        gargbageBinParams.onInteractionComplete?.Invoke();
    }
}

public class GargbageBinInteractiveParams : BaseInteractiveParams
{
    public Action onInteractionComplete;
    public Order order;

    public GargbageBinInteractiveParams(Action onInteractionComplete, Order order)
    {
        this.onInteractionComplete = onInteractionComplete;
        this.order = order;
    }
}
