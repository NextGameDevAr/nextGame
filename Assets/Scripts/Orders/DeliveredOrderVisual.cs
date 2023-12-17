using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveredOrderVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    public void PlayDeliverAnimation(bool isCorrect)
    {
        var main = particles.main;
        main.startColor = isCorrect ? Color.green : Color.red;
        particles.Play();
    }
}
