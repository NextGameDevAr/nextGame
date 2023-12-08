using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private Station currentStation;
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (MouseWorld.TryToGetStation(out currentStation)) {
                if (currentStation.IsWorking())
                {
                    currentStation.IncreaseProgress();
                } else
                {
                    unit.Move(currentStation.GetFrontPosition(), () => currentStation.StartInteraction(OnFInish)); ;
                }
            }
        }
    }

    private void OnFInish(Item item)
    {
        currentStation = null;
        unit.SetItem(item);
    }
}
