using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderCounterVisual : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject imageGroup;

    private void Start()
    {
        imageGroup.SetActive(false);
    }
    public void ShowOrder(Sprite image)
    {
        this.image.sprite = image;
        imageGroup.SetActive(true);
    }

    public void HideOrder()
    {
        imageGroup.SetActive(false);
    }
}
