using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulseRing : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 0.5F;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;
    }

    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(500, 50, 100, 30), hSliderValue, 0.0F, 5.0F);
    }
}
