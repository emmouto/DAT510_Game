using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GUIManager : MonoBehaviour {
    public static GUIManager instance;

    public TMP_Text scoreText;
    public TMP_Text moveCounterText;

    private int score;
    private int moveCounter;
    public int maxMoves;

    private int fireScore;
    private int earthScore;
    private int waterScore;
    private int airScore;
    private int lightScore;
    private int darkScore;

    public int Score {
        get {
            return score;
        }

        set {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    // Might not need this idk but I'll keep it for now since I wasted a minute writing it
    public int getElementalScore(string element) {
        switch (element) {
            case "Fire":
                return fireScore;
            case "Earth":
                return earthScore;
            case "Water":
                return waterScore;
            case "Air":
                return earthScore;
            case "Light":
                return lightScore;
            case "Dark":
                return darkScore;
            default:
                return score;
        }
    }

    public int MoveCounter {
        get {
            return moveCounter;
        }

        set {
            moveCounter = value;
            if (moveCounter >= maxMoves) {
                moveCounter = 0;
                StartCoroutine(WaitForShifting());
            }
            moveCounterText.text = "Move " + moveCounter.ToString() + " / " + maxMoves.ToString();
        }
    }

    void Awake() {
        instance = GetComponent<GUIManager>();
        moveCounter = 1;
        moveCounterText.text = "Move " + moveCounter.ToString() + " / " + maxMoves.ToString();
    }

    private IEnumerator WaitForShifting() {
        yield return new WaitUntil(() => !GridManager.instance.IsShifting);
        yield return new WaitForSeconds(.25f);
        GameFinished();
    }

    private void GameFinished() {
        SceneManager.LoadScene(sceneName: "Match3-Crafting");
    }

}
