using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Rendering.DebugUI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    
    void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
        inventory = FindObjectOfType<Inventory>();
        
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScore.text = highScore.ToString();

        
    }
       
    public void UpdateGold()
    {
        inventoryUI.UpdateGoldText(inventory);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
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
        inventory.NumberOfDiamonds =  PlayerPrefs.GetInt("coins");
       
        player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
        Time.timeScale = 1f;
    }
    public void HighScore()
    {
        int currentScore = inventory.NumberOfDiamonds;
        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            _highScore.text = highScore.ToString();
            
        }
    }
    public void CurrentScore()
    {
        _currentScore.text = inventory.NumberOfDiamonds.ToString();
    }
}
