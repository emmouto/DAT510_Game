using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfusionBarManager : MonoBehaviour {
    public Slider slider;

    private float currentValue = 0f;
    public float CurrentValue {
        get {
            return currentValue;
        }

        set {
            currentValue = value;
            slider.value = currentValue;
        }
    }

    void Start() {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update() {
        CurrentValue += 0.0043f;
    }
}

// https://fractalpixels.com/devblog/unity-2D-progress-bars