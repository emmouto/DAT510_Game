using System.Collections;
using System.Collections.Generic;
using System.Globalization; 
using UnityEngine;
using UnityEngine.UI;

public class QTEButton : MonoBehaviour{

    public Button qteButton;
    public float timer = 0;
    public bool accelerate = false;
    public GameObject popUpPanel;

    public float maxTimer;
    public float minTimer;


    // Start is called before the first frame update
    void Start(){
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;  //can't click outside of image
        qteButton.onClick.AddListener(() =>
        {
            //PopUp popUp = UIController.Instance.CreatePopUp();
            //popUp.init(UIController.Instance.MainCanvas,
            //"It didn't go very well this time. Unfortunately the potion isn't well done ...",
            //"Good job! You now have a perfect potion",
            //"x"
            //);

                                                                               //testa particle system curves 0.4

            
            if (timer > 0.000953 & timer < 0.0015754)
            {
                Debug.Log("Button is clicked well");

                popUpPanel.SetActive(true);
            }

            //else if (timer > 0.0015754 & timer < 0.000953){
            //    Debug.Log("Button is clicked badly");
            //}

        });
        

    }

   /* void onTimeClick() {
        Debug.Log("You get a very well formed potion");

    }*/

   

   /* void clickTrue()
    {
        accelerate = true;
    }*/

    // Update is called once per frame
    void Update(){
        timer = Time.deltaTime;

     
        //accelerate = false;
        //if (accelerate)
        //{
        //    popUpPanel.SetActive(false);
        //}


        
    }
}
