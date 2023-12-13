using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private Transform frontPosition;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Transform itemPrefab;
    [SerializeField] private Action<Item> OnStationFinish;
    [SerializeField] private bool isWorking;
    [SerializeField] private float currentProgrees;


    public Vector3 GetFrontPosition()
    {
        return frontPosition.position;
    }

    private void Update()
    {
        if(currentProgrees > 100)
        {
            isWorking = false;
            currentProgrees = 0;
            Item item = Instantiate(itemPrefab).GetComponent<Item>(); 
            OnStationFinish?.Invoke(item);
        }

        if(isWorking)
        {
            currentProgrees +=  Time.deltaTime * 10;
            progressBar.UpdateProgress(currentProgrees/100);
        }
    }

    public void StartInteraction(Action<Item> onStationFinish)
    {
        OnStationFinish = onStationFinish;
        isWorking = true;
    }

    public void IncreaseProgress()
    {
        currentProgrees += 10f;
        progressBar.UpdateProgress(currentProgrees / 100);
    }
    public bool IsWorking()
    {
        return isWorking;
    }
}
