using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void showScore() {
        SFXManager.instance.PlaySFX(Clip.Select);
        SceneManager.LoadScene("TotalScore");
    }
        

}
