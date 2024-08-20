using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Sleep hier je TextMeshProUGUI component in via de Inspector

    protected int score;

    void Start()
    {
        // Begin met een score van 0
        score = 0;
        IncrementScore();
    }

    public void IncrementScore()
    {
        // Verhoog de score met 1
        score = score + 1;
        Debug.Log("log3");
        
        
            Debug.Log("log4");
            scoreText.text = "Score: " + score;

    }
    public int GetScore()
    {
        return score;
    }

    // Methode om de score in te stellen
    public void SetScore(int newScore)
    {
        score = newScore;
        IncrementScore();
    }

}
