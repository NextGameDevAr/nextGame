using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Station : MonoBehaviour, IInteractive, IPointerClickHandler
{
    [SerializeField] private Transform unitSpot;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private OrderSO orderSO;
    [SerializeField] private Action<Order> OnStationInteractionComplete;
    [SerializeField] private bool isBusy;
    [SerializeField] private float currentProgrees;

    private void Update()
    {
        if(currentProgrees > 100)
        {
            isBusy = false;
            currentProgrees = 0;
            OnStationInteractionComplete?.Invoke(CreateItem());
        }

        if(isBusy)
        {
            currentProgrees +=  Time.deltaTime * 10;
            progressBar.UpdateProgress(currentProgrees/100);
        }
    }
    public void IncreaseProgress()
    {
        if (isBusy)
        {
            currentProgrees += 10f;
            progressBar.UpdateProgress(currentProgrees / 100);
        }
    }
    public bool IsBusy()
    {
        return isBusy;
    }

    private Order CreateItem()
    {
        Transform item = Instantiate(orderSO.item.prefab);
        item.gameObject.name = orderSO.id;
        return item.GetComponent<Order>();
    }

    public Vector3 GetUnitSpotPosition()
    {
        return unitSpot.position;
    }

    public void Interact(BaseInteractiveParams interactiveParams)
    {
        isBusy = true;
        StationInteractiveParams stationParams = interactiveParams as StationInteractiveParams;
        OnStationInteractionComplete = stationParams.onStationInteractionComplete; ;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IncreaseProgress();
    }
}

public class StationInteractiveParams : BaseInteractiveParams
{
    public Action<Order> onStationInteractionComplete;

    public StationInteractiveParams(Action<Order> onStationInteractionComplete)
    {
        this.onStationInteractionComplete = onStationInteractionComplete;
    }
}
