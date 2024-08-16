using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI _highScore;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScore.text = highScore.ToString();
    }

}
