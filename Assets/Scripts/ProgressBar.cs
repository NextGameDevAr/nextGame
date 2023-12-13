using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressImage;

    private void Start()
    {
        gameObject.transform.LookAt(Camera.main.transform);
        gameObject.SetActive(false);
    }

    public void UpdateProgress(float progress)
    {
        if(progress > 1)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
            progressImage.fillAmount = progress;
        }
    }
   
    
}
