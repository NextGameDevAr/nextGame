using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class ItemSOList<T> : ScriptableObject
{
    public List<T> list;

    public T GetRandomItem()
    {
        return list[Random.Range(0, list.Count)];
    }
    
}
