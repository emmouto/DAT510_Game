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
        // unsure if I'll even use this, probably not
    }

    public void fillBar() {
        CurrentValue += 0.05f; // temp value, makes the jump from 0 look not shit due to the colour spilling outside of the border
    }
}

// https://fractalpixels.com/devblog/unity-2D-progress-bars