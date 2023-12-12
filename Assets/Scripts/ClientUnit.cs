using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientUnit : Unit
{
    [SerializeField] private OrderCounter currentOrderCounter;

    public void SetOrderCounter(OrderCounter orderCounter)
    {
        currentOrderCounter = orderCounter;
        moveAction.Move(orderCounter.GetClientSpot(), MakeAnOrder);
    }
    private void MakeAnOrder()
    {
        currentOrderCounter.MakeAnOrder(LeaveOrderCounter);
    }

    private void LeaveOrderCounter()
    {
        moveAction.Move(ClientUnitSystem.Instance.GetClientUnitExitPosition(), SetAsAvaliable);
    }

    private void SetAsAvaliable()
    {
        ClientUnitSystem.Instance.AddClientAsAvailable(this);
    }
}
