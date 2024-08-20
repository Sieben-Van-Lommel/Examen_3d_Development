using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class SaveLoadManager : MonoBehaviour
{
    GameManager gameManager;
    public Transform player;
    Vector3 playerPosition;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save() 
    {
        PlayerPrefs.SetInt("score", scoreManager.GetScore());
        Debug.Log("Saving");
        playerPosition = player.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
    }
    public void Load() 
    {
        Debug.Log("loading");
        int score = PlayerPrefs.GetInt("score", 0); // Standaard waarde 0
        scoreManager.SetScore(score); // Werk de score bij

        player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
        Time.timeScale = 1f;
    }
}
