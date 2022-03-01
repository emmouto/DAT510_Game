using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngrediencePicker : MonoBehaviour {
    public Toggle toggle1;
    public Toggle toggle2;
    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start() {
        Toggle toggle1_2 = toggle1.GetComponent<Toggle>();
        Toggle toggle2_2 = toggle2.GetComponent<Toggle>();
        Button button1_2 = button1.GetComponent<Button>();
        Button button2_2 = button2.GetComponent<Button>();
        Button button3_2 = button3.GetComponent<Button>();
        toggle1_2.onValueChanged.AddListener((value) => togglePress1());
        toggle2_2.onValueChanged.AddListener((value) => togglePress2());
        button1_2.onClick.AddListener(buttonPress1);
        button2_2.onClick.AddListener(buttonPress2);
        button3_2.onClick.AddListener(buttonPress3);
    }
    
    private void togglePress1() {
        toggle1.interactable = false;
        SFXManager.instance.PlaySFX(Clip.Select);
    }
    
    private void togglePress2() {
        toggle2.interactable = false;
        SFXManager.instance.PlaySFX(Clip.Select);
    }

    void buttonPress1() {
        toggle1.interactable = true;
        SFXManager.instance.PlaySFX(Clip.Select);
    }

    void buttonPress2() {
        toggle2.interactable = true;
        SFXManager.instance.PlaySFX(Clip.Select);
    }
    
    void buttonPress3() {
        SFXManager.instance.PlaySFX(Clip.Select);
        SceneManager.LoadScene(sceneName: "Match3");
    }
}
