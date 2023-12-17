using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To work is require that the gameObject sorting layer is Interactive
public interface IInteractive 
{
    public Vector3 GetUnitSpotPosition();
    public void Interact(BaseInteractiveParams interactiveParams);
}


public abstract class BaseInteractiveParams
{
}
