using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    public Button tutorialButton;
    public Button startGameButton;

    void Start() {
        Button btn1 = tutorialButton.GetComponent<Button>(); 
        Button btn2 = startGameButton.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
    }
    void TaskOnClick1() {
        SFXManager.instance.PlaySFX(Clip.Select);
        Application.OpenURL("https://xd.adobe.com/view/51c52058-2668-49ef-8727-720c366b55e7-0496/?fullscreen");
    }
    void TaskOnClick2() {
        SFXManager.instance.PlaySFX(Clip.Select);
        SceneManager.LoadScene(sceneName: "IngrediencePicker");
    } 
}