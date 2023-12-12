using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClientUnitSystem : Singleton<ClientUnitSystem>
{
    [SerializeField] private Transform exitPosition;
    [SerializeField] private List<ClientUnit> avaiableClientUnitList;
    [SerializeField] private List<OrderCounter> avaiableOrderCounterList;

    private void Start()
    {
        avaiableOrderCounterList = FindObjectsOfType<OrderCounter>().ToList();
        SendClient();
    }

    public void SendClient()
    {
        ClientUnit client = avaiableClientUnitList.First();
        avaiableClientUnitList.Remove(client);
        OrderCounter orderCounter = avaiableOrderCounterList.First();
        avaiableOrderCounterList.Remove(orderCounter);
        client.SetOrderCounter(orderCounter);
    }

    public Vector3 GetClientUnitExitPosition()
    {
        return exitPosition.position;
    }

    public void AddClientAsAvailable(ClientUnit clientUnit)
    {
        avaiableClientUnitList.Add(clientUnit);
    }

    public void AddOrderCounterAsAvailable(OrderCounter orderCounter)
    {
        avaiableOrderCounterList.Add(orderCounter);
    }
}
