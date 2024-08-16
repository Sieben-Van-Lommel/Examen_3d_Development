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
        redGhostScript = FindAnyObjectByType<RedGhostScript>();
        greenGhostScript = FindAnyObjectByType<GreenGhostScript>();  
        pacManScript = FindAnyObjectByType<PacManScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedGhost"))
        {
            redGhostScript.DamageTaken();
        }
        if (collision.gameObject.CompareTag("GreenGhost"))
        {
            greenGhostScript.DamageTaken();
        }
        if (collision.gameObject.CompareTag("PacMan"))
        {
            pacManScript.DamageTaken();
        }
    }
}
