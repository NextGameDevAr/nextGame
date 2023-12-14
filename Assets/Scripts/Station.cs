using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Station : MonoBehaviour, IInteractive, IPointerClickHandler
{
    [SerializeField] private Transform unitSpot;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Transform itemPrefab;
    [SerializeField] private Action OnStationFinish;
    [SerializeField] private bool isWorking;
    [SerializeField] private float currentProgrees;

    private void Update()
    {
        if(currentProgrees > 100)
        {
            isWorking = false;
            currentProgrees = 0;
            OnStationFinish?.Invoke();
        }

        if(isWorking)
        {
            currentProgrees +=  Time.deltaTime * 10;
            progressBar.UpdateProgress(currentProgrees/100);
        }
    }
    public void IncreaseProgress()
    {
        if (isWorking)
        {
            currentProgrees += 10f;
            progressBar.UpdateProgress(currentProgrees / 100);
        }
    }
    public bool IsWorking()
    {
        return isWorking;
    }

    public Vector3 GetUnitSpotPosition()
    {
        return unitSpot.position;
    }

    public void Interact(Action onStationFinish)
    {
        isWorking = true;
        OnStationFinish = onStationFinish;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pointerclcilk");
        IncreaseProgress();
    }
}
