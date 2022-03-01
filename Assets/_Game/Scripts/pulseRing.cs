using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulseRing : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 0.5F;
    public ParticleSystem.Particle[] outArray;

    public Button qteButton;
    public float timer = 0;
    public bool accelerate = false;
    public GameObject popUpPanel;
    public float particleSize;

    public float sizeOfParticle;

/* public float maxTimer;
 public float minTimer;

 //ParticleSystem.MinMaxCurve.Evaluate ASK THEM*/



void Start() {
        
        ps = GameObject.Find("PulseRing").GetComponent<ParticleSystem>();
        outArray = new ParticleSystem.Particle[1000];
        ButtonClicked();
    }

    public float SizeParticle()
    {
        ps.GetParticles(outArray);
        particleSize = outArray[0].GetCurrentSize(ps);
        return particleSize;
    }

    void Update()
    {

       // var main = ps.main;
        //main.simulationSpeed = hSliderValue;

        sizeOfParticle = SizeParticle();
        
       // Debug.Log(SizeParticle);
    }


    public void ButtonClicked(){


        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;  //can't click outside of image
        qteButton.onClick.AddListener(() =>
        {

            if (sizeOfParticle > 1.045 && sizeOfParticle < 1.5)
            {
                Debug.Log("Button is clicked well");

                popUpPanel.SetActive(true);
            }
            else if (sizeOfParticle > 1.5){
                Debug.Log("Button is clicked bad");
                popUpPanel.SetActive(true);

            }


        });

    }

    /*void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(500, 50, 100, 30), hSliderValue, 0.0F, 5.0F);
    }*/
}
