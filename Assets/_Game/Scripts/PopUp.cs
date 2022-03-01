using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopUp : MonoBehaviour
{
   public GameObject popUpBox;
    //public Animator animator;
   

    [SerializeField] Button button1; //close
    [SerializeField] Button button2; //continue
    [SerializeField] Text buttonText1;
    [SerializeField] Text buttonText2;
    [SerializeField] Text popUpText;

    public void init(Transform canvas, string popUpMessage, string btnText1, string btnText2){
        popUpText.text = popUpMessage;
        buttonText1.text = btnText1;
        buttonText2.text = btnText2;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;


        //button1.onClick.AddListener(() =>{
        //    GameObject.Destroy(this.gameObject);
        //});


    }

    public void cancelClick(Button button){
        button.onClick.AddListener(() =>
        {
            popUpBox.SetActive(false);
        });
    }

  

    //void Start()  {
    //    Button button = GetComponent<Button>();
    //    button.onClick.AddListener(() => {
    //        PopUp popup = UIController.Instance.CreatePopUp();
    //        popup.init(UIController.Instance.MainCanvas,
    //            "Good job",
    //            "Bad job",
    //            "It's ok",
    //            action
    //            );
    //    });
    //}



}
