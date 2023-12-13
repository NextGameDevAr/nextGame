using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    [SerializeField] private LayerMask mousePlaneLayerMask;
    [SerializeField] private LayerMask mouseStationLayerMask;

    private void Awake()
    {
        instance = this;
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

    public static bool TryToGetStation(out Station station)
    {
        station = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isStation = Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mouseStationLayerMask);
        if(isStation)
        {
            station = raycastHit.collider.GetComponent<Station>();
        }
        return isStation;
    }
}
