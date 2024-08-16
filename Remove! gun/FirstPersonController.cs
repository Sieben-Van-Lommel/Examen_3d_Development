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
        if (!gameManager.isPaused)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }


            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }

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