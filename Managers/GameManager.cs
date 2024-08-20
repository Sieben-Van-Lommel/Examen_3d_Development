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
    // Singleton instance
    private static GameManager instance;
    private static readonly object lockObject = new object();

    // Properties to access the singleton instance
    public static GameManager Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    // Zoek de GameManager in de scène
                    instance = FindObjectOfType<GameManager>();

                    if (instance == null)
                    {
                        // Creëer een nieuw GameObject als er geen instance gevonden wordt
                        GameObject singletonObject = new GameObject("GameManager");
                        instance = singletonObject.AddComponent<GameManager>();
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return instance;
            }
        }
    }
    /*
    // Inventory
    public static InventoryUI inventoryUI;
    public static Inventory inventory;

    // Menu
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool isPaused;
    public GameObject endScreen;

    // Player
    public Transform player;
    Vector3 playerPosition;

    // Score
    public TextMeshProUGUI _highScore;
    public TextMeshProUGUI _currentScore;
    int highScore;

    private void Awake()
    {
        // Zorg ervoor dat er maar één instantie van GameManager is
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Score manager
        inventoryUI = FindObjectOfType<InventoryUI>();
        inventory = FindObjectOfType<Inventory>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScore.text = highScore.ToString();

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        endScreen.SetActive(false);
    }

    // GameManager  
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
        pauseMenu.SetActive(true);
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Endscreen activated.");
    }

    // SaveLoadManager
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
        player.position = new Vector3(
            PlayerPrefs.GetFloat("playerPositionX"),
            PlayerPrefs.GetFloat("playerPositionY"),
            PlayerPrefs.GetFloat("playerPositionZ")
        );
        Time.timeScale = 1f;
    }

    // Score manager
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
    }*/

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
        endScreen.SetActive(false);

        // Zorg ervoor dat de ScoreManager correct is gevonden en ingesteld
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found. Make sure there is a ScoreManager in the scene.");
        }

        // Zorg ervoor dat de GameMenuManager correct is gevonden en ingesteld
        gameMenuManager = FindObjectOfType<GameMenuManager>();
        if (gameMenuManager == null)
        {
            Debug.LogError("GameMenuManager not found. Make sure there is a GameMenuManager in the scene.");
        }
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
    public void Dead()
    {
        pauseMenu.SetActive(true);
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Endscreen activated.");
    }
}  
