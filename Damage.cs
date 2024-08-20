using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameManager gameManager;

    GameObject gameObjectToDeactivate;


    public AudioSource m_MyAudioSource;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        gameObjectToDeactivate = GameObject.Find("EndScreen");
        if (gameObjectToDeactivate != null)
        {
            gameObjectToDeactivate.SetActive(false);
        }

        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);

        if (other.CompareTag("RedGhost") ||
            other.CompareTag("GreenGhost") ||
            other.CompareTag("PacMan"))
        {
            Debug.Log("Collision with tagged object detected.");
            Time.timeScale = 0f; // Pauzeer het spel
            if (gameObjectToDeactivate != null)
            {
                gameManager.Dead();
                gameObjectToDeactivate.SetActive(true);
            }
            gameManager.HighScore();
            gameManager.CurrentScore();
        }
    }

}