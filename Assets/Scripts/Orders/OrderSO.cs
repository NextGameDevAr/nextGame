using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderSO", menuName = "SO/OrderSO", order = 1)]
[Serializable]
public class OrderSO : ScriptableObject
{
    public int id;
    public OrderItem item;
    public int value;
}

[Serializable]
public class OrderItem
{
    public int name;
    public Transform prefab;
    public Sprite sprite;
}
