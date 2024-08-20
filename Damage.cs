using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameManager gameManager;

    // Verwijder de volgende variabelen als ze niet meer nodig zijn
    // public float walkingSpeed = 7.5f;
    // public float runningSpeed = 11.5f;
    // public float jumpSpeed = 8.0f;
    // public float gravity = 20.0f;
    // public Camera playerCamera;
    // public float lookSpeed = 2.0f;
    // public float lookXLimit = 45.0f;

    // Verwijder de volgende variabelen als ze niet meer nodig zijn
    // CharacterController characterController;
    // Vector3 moveDirection = Vector3.zero;
    // float rotationX = 0;

    // [HideInInspector]
    // public bool canMove = true;

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
        // Verwijder de beweging en rotatie logica als deze niet nodig is
        // Je kunt deze methoden leeg laten of verwijderen als je ze niet nodig hebt

        // Voorbeeld:
        // HandleMovement();
        // HandleRotation();
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