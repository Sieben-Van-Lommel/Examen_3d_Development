using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private RedGhostScript redGhostScript;
    private GreenGhostScript greenGhostScript;
    private PacManScript pacManScript;

    void Awake()
    {
        redGhostScript = FindObjectOfType<RedGhostScript>();
        greenGhostScript = FindObjectOfType<GreenGhostScript>();
        pacManScript = FindObjectOfType<PacManScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Controleer of GameManager.Instance null is
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null! Zorg ervoor dat de GameManager correct is ingesteld.");
            return;
        }

        if (collision.gameObject.CompareTag("RedGhost"))
        {
            redGhostScript.DamageTaken();
            GameManager.Instance.UpdateGold();
        }
        else if (collision.gameObject.CompareTag("GreenGhost"))
        {
            greenGhostScript.DamageTaken();
            GameManager.Instance.UpdateGold();
        }
        else if (collision.gameObject.CompareTag("PacMan"))
        {
            pacManScript.DamageTaken();
            GameManager.Instance.UpdateGold();
        }
    }
}
