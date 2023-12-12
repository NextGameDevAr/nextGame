using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : Singleton<OrderSystem>
{
    [SerializeField]private ItemSOList<OrderSO> availableOrders;

    public OrderSO GetAnOrder()
    {
        return availableOrders.GetRandomItem();
    }

}
