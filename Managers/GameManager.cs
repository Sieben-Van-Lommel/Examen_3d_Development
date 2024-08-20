using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Rendering.DebugUI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{ 
    //inventory
    public static InventoryUI inventoryUI;
    public static Inventory inventory;
    //menu
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool isPaused;
    public GameObject endScreen;

    //player
    public Transform player;
    Vector3 playerPosition;
    //score
    public TextMeshProUGUI _highScoreMainMenu;
    public TextMeshProUGUI _currentScore;
    public TextMeshProUGUI _highScore;
    int highScore;


    void Start()
    {
        //scoremanager
        inventoryUI = FindObjectOfType<InventoryUI>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScore.text = highScore.ToString();

        //Gamemanager
        inventory = FindObjectOfType<Inventory>();

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

        endScreen.SetActive(false);

    }
    //GameManager  
    public void UpdateGold()
    {
        inventoryUI.UpdateGoldText(inventory);
    }

    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void Back()
    {
        optionsMenu.SetActive(false);
    }

    public void Dead()
    {
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    /// <summary>
    /// ////////////////////////////////////////////////:
    /// </summary>
    /// 
    //SaveLoadManager, done
    public void SavePlayer()
    {
        PlayerPrefs.SetInt("coins", inventory.NumberOfDiamonds);

        playerPosition = player.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
    }
    public void LoadPlayer()
    {
        inventory.NumberOfDiamonds = PlayerPrefs.GetInt("coins");

        player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
        Time.timeScale = 1f;
    }

    //Scoremanager
    public void HighScore()
    {
        int currentScore = inventory.NumberOfDiamonds;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            _highScore.text = highScore.ToString();

        }
    }
    public void CurrentScore()
    {
        _currentScore.text = inventory.NumberOfDiamonds.ToString();
    }/*
    //inventory
    public static InventoryUI inventoryUI;
    public static Inventory inventory;
    //menu
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool isPaused;

    //player
    public Transform player;
    Vector3 playerPosition;
    //score
    public TextMeshProUGUI _highScoreMainMenu;
    public TextMeshProUGUI _currentScore;
    public TextMeshProUGUI _highScore;
    int highScore;

    private SaveLoadManager saveLoadManager;
    private ScoreManager scoreManager;
    private GameMenuManager gameMenuManager;


    void Start()
    {
        //scoremanager
        inventoryUI = FindObjectOfType<InventoryUI>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScore.text = highScore.ToString();

        //Scoremanager
        inventory = FindObjectOfType<Inventory>();

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        //gamemenu
        gameMenuManager = FindObjectOfType<GameMenuManager>();


    }
    //saveloadmanager aanroepen
    public void SavePlayer()
    {
        saveLoadManager.Save();
    }
    public void LoadPlayer()
    {

    }
    //scoremanager aanroepen
    public void HighScore()
    {
        scoreManager._HighScore();
    }
    public void CurrentScore()
    {
        scoreManager._CurrentScore();
    }
    public void UpdateGold()
    {
        inventoryUI.UpdateGoldText(inventory);
    }
    //GameMenuManager aanroepen
    public void ResumeGame()
    {
        gameMenuManager.Resume();
    }

    public void Options()
    {
        gameMenuManager.OptionsMenu();
    }
    public void Back()
    {
        gameMenuManager.BackButton();
    }
    public class GameManagerr : MonoBehaviour
    {
    }*/
}
