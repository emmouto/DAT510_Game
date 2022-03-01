using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulseRing : MonoBehaviour {
    //particle system
    private ParticleSystem ps;
    //public float hSliderValue = 0.5F;
    public ParticleSystem.Particle[] outArray;
    public float particleSize;
    public float sizeOfParticle;

    //button
    public Button qteButton;
    public bool accelerate = false;

    //Messagebox
    public GameObject popUpPanel;
    public Text popUpText;

    /* public float maxTimer;
     public float minTimer;

     //ParticleSystem.MinMaxCurve.Evaluate ASK THEM*/

    void Start() {
        ps = GameObject.Find("PulseRing").GetComponent<ParticleSystem>();
        outArray = new ParticleSystem.Particle[1000];
        ButtonClicked();
    }

    public float SizeParticle() {
        ps.GetParticles(outArray);
        particleSize = outArray[0].GetCurrentSize(ps);
        return particleSize;
    }

    void Update() {
        sizeOfParticle = SizeParticle();
       // Debug.Log(SizeParticle);
    }


    public void ButtonClicked() {
        //this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;  //can't click outside of image
        qteButton.onClick.AddListener(() => {
            if (sizeOfParticle > 1.045 && sizeOfParticle < 1.5){ 
                popUpPanel.SetActive(true);
                popUpText.text = "Good job! Your potion will be made well :)";
            } else if (sizeOfParticle > 1.5){
                popUpPanel.SetActive(true);
                popUpText.text = "Better luck next time! Your potion will not be made well :( ";
            }
        });
    }
}
