using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientUnit : Unit
{
    [SerializeField] private OrderCounter currentOrderCounter;

    public void StartBuying(OrderCounter orderCounter, Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        currentOrderCounter = orderCounter;
        moveAction.Move(orderCounter.GetClientSpot(), WaitToBeAttended);
    }


    private void WaitToBeAttended()
    {
        currentOrderCounter.SetClient(this);
    }
    private void MakeAnOrder()
    {
        currentOrderCounter.MakeAnOrder(LeaveOrderCounter);
    }

    public void LeaveOrderCounter()
    {
        moveAction.Move(ClientUnitSystem.Instance.GetClientUnitExitPosition(), SetAsAvaliable);
    }

    private void SetAsAvaliable()
    {
        ClientUnitSystem.Instance.AddClientAsAvailable(this);
    }

    internal override void Interact()
    {
        throw new System.NotImplementedException();
    }
}
