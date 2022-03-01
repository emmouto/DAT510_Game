using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PotionContinueButton : MonoBehaviour {
    public Button continueButton;

    void Start() {
        Button btn = continueButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        SceneManager.LoadScene(sceneName: "Match3"); // TODO Change to rhythm game scene
    }
}
