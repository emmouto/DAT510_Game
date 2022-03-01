using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    public Button tutorialButton;
    public Button startGameButton;

    void Start() {
        Debug.Log("start");
        Button btn1 = tutorialButton.GetComponent<Button>(); 
        Button btn2 = startGameButton.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
    }
    void TaskOnClick1() {
        Debug.Log("Tutorial button click!");
        Application.OpenURL("https://www.google.com/");
    }
    void TaskOnClick2() {
        Debug.Log("Tutorial button click!");
        SceneManager.LoadScene(sceneName: "IngrediencePicker");
    } 
}