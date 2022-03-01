using System;
using System.Linq;
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
    private int scoreGoal;
    private int moveCounter;
    private int maxMoves;
    private bool potionSuccess;

    List<Elements> goodElements = new();
    List<Elements> badElements = new();
    List<Elements> neutralElements = new();
    List<Elements> allElements = new();
    List<Elements> matchHistory = new();

    public int Score {
        get {
            return score;
        }

        set {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    public bool getPotionSuccess() { return potionSuccess; }

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
        setElements();
        moveCounter = 1;
        maxMoves = 15;
        scoreGoal = 3000;
        moveCounterText.text = "Move " + moveCounter.ToString() + " / " + maxMoves.ToString();
    }

    private IEnumerator WaitForShifting() {
        yield return new WaitUntil(() => !GridManager.instance.IsShifting);
        yield return new WaitForSeconds(.25f);
        GameFinished();
    }

    private void GameFinished() {
        if (score >= scoreGoal) {
            potionSuccess = true;
        } else {
            potionSuccess = false;
        }
        
        SceneManager.LoadScene(sceneName: "Match3-Crafting");
    }

    private void setElements() {
        // temp
        goodElements.Add(Elements.Earth); 
        goodElements.Add(Elements.Water);
        allElements.Add(Elements.Earth); 
        allElements.Add(Elements.Water);
        
        foreach (Elements e in goodElements) {
            badElements.Add(e.opposite());
            allElements.Add(e.opposite());
        }

        if (allElements.Count < 5) {
            foreach (Elements e in Enum.GetValues(typeof(Elements))) {
                if (!allElements.Contains(e)) {
                    neutralElements.Add(e);
                }
            }
        }
    }

    public void addScore(string e1) {
        Elements e2;
        Enum.TryParse<Elements>(e1, true,  out e2);
        int additionalScore = 0;

        if (goodElements.Contains(e2)) {
            additionalScore += 100;
        } else if (badElements.Contains(e2)) {
            additionalScore += 10;
        } else {
            additionalScore += 50;
        }

        score += additionalScore;
        matchHistory.Add(e2);
        scoreText.text = score.ToString();
    }
}
