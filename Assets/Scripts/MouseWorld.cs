using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    [SerializeField] private LayerMask mousePlaneLayerMask;
    [SerializeField] private LayerMask mouseInteractiveLayerMask;

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

    public static bool TryToGetInteractive(out IInteractive interactive)
    {
        interactive = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isStation = Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mouseInteractiveLayerMask);
        if(isStation)
        {
            interactive = raycastHit.collider.GetComponent<IInteractive>();
        }
        return isStation;
    }
}
