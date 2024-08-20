using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    GameManager gameManager;

    GameObject gameObjectToDeactivate;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        gameObjectToDeactivate = GameObject.Find("EndScreen");
        if (gameObjectToDeactivate != null)
        {
            gameObjectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogError("EndScreen GameObject not found.");
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);

            if (collision.gameObject.CompareTag("RedGhost") ||
                collision.gameObject.CompareTag("GreenGhost") ||
                collision.gameObject.CompareTag("PacMan"))
            {
                Debug.Log("Collided with a tagged object.");

                // Stop het spel
                Time.timeScale = 0f;

                // Activeer EndScreen als het niet null is
                if (gameObjectToDeactivate != null)
                {
                    gameObjectToDeactivate.SetActive(true);
                }
                else
                {
                    Debug.LogError("EndScreen GameObject is null.");
                }

                // Roep de methodes aan van GameManager
                if (gameManager != null)
                {
                    gameManager.HighScore();
                    gameManager.CurrentScore();
                }
                else
                {
                    Debug.LogError("GameManager reference is null.");
                }
            }
        }
    }
}