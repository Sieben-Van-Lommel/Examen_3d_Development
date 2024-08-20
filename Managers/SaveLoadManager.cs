using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class SaveLoadManager : MonoBehaviour
{
    GameManager gameManager;
    public Transform player;
    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save() 
    {
        PlayerPrefs.SetInt("coins", inventory.NumberOfDiamonds);

        playerPosition = player.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);
    }
    public void Load() 
    {

        inventory.NumberOfDiamonds = PlayerPrefs.GetInt("coins");

        player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"), PlayerPrefs.GetFloat("playerPositionZ"));
        Time.timeScale = 1f;
    }
}
