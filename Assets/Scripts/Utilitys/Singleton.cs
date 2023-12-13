using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Debug.LogError("Double instance: " + name);
            Destroy(gameObject);
        }
    }

}
