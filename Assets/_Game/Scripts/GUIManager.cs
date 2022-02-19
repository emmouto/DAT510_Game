using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public int MoveCounter {
        get {
            return moveCounter;
        }

        set {
            moveCounter = value;
            moveCounterText.text = "Move " + moveCounter.ToString() + " / " + maxMoves.ToString();
        }
    }

    void Awake() {
        instance = GetComponent<GUIManager>();
        moveCounter = 1;
        moveCounterText.text = "Move " + moveCounter.ToString() + " / " + maxMoves.ToString();
    }

}
