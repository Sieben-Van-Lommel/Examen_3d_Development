using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI _highScore;
    public TextMeshProUGUI _currentScore;
    private Inventory inventory;
    public static InventoryUI inventoryUI;

    private int highScore;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        if (inventory == null)
        {
            Debug.LogError("Inventory reference is missing.");
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (_highScore != null)
        {
            _highScore.text = highScore.ToString();
        }
        inventoryUI = FindObjectOfType<InventoryUI>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScore.text = highScore.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _HighScore()
    {
        int currentScore = inventory.NumberOfDiamonds;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            _highScore.text = highScore.ToString();

        }
    }
    public void _CurrentScore()
    {
        _currentScore.text = inventory.NumberOfDiamonds.ToString();
    }
    public void UpdateGold()
    {
        inventoryUI.UpdateGoldText(inventory);
    }
}
