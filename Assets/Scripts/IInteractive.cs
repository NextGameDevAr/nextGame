using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive 
{
    public Vector3 GetUnitSpotPosition();
    public void Interact(BaseInteractiveParams interactiveParams);
}


public class BaseInteractiveParams
{
    public Action baseOnInteractionComplete;

    public BaseInteractiveParams(Action baseOnInteractionComplete)
    {
        this.baseOnInteractionComplete = baseOnInteractionComplete;
    }
}
