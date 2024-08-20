using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour
{

    GameManager gameManager;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    GameObject gameObjectToDeactivate;

    public AudioSource m_MyAudioSource;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        gameManager = FindAnyObjectByType<GameManager>();

        gameObjectToDeactivate = GameObject.Find("EndScreen");
        gameObjectToDeactivate.SetActive(false);

        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedGhost"))
        {
            Time.timeScale = 0f;
            gameObjectToDeactivate.SetActive(true);
            gameManager.HighScore();
            gameManager.CurrentScore();
        }
        if (collision.gameObject.CompareTag("GreenGhost"))
        {
            Time.timeScale = 0f;
            gameObjectToDeactivate.SetActive(true);
            gameManager.HighScore();
            gameManager.CurrentScore();
        }
        if (collision.gameObject.CompareTag("PacMan"))
        {
            Time.timeScale = 0f;
            gameObjectToDeactivate.SetActive(true);
            gameManager.HighScore();
            gameManager.CurrentScore();
        }

    }
}