using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Match3Results : MonoBehaviour {
    public TMP_Text successOrFailureText;
    public Button continueButton;

    void Awake() {
        if (GUIManager.instance.getPotionSuccess()) { 
            successOrFailureText.text = "Success! :)";
        } else {
            successOrFailureText.text = "Failure!";
        }

    }

    void Start() {
        Button btn = continueButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        SceneManager.LoadScene(sceneName: "Match3"); // TODO Change to rhythm game scene
    }
}
