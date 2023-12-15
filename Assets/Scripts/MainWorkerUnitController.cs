using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWorkerUnitController : Singleton<MainWorkerUnitController>
{
    [SerializeField] private WorkerUnit mainUnit;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(MouseWorld.TryToGetInteractive(out IInteractive interactive)) {
                mainUnit.Move(interactive);
            }
        }
    }
}
