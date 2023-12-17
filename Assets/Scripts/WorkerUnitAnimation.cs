using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerUnitAnimation : UnitAnimation
{
    [SerializeField] private WorkerUnit workerUnit;
    private const string IS_WORKING = "IsWorking";


    private void Start()
    {
        if(workerUnit == null)
        {
            workerUnit = GetComponent<WorkerUnit>();
        }
        workerUnit.OnStationInteraction += HandlerWorkingAnimation;
    }

    private void HandlerWorkingAnimation(bool isWorking)
    {
        animator.SetBool(IS_WORKING, isWorking);
    }
}
