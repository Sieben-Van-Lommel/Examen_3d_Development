using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedGhostScript : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Zoek de ScoreManager in de scène
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found. Make sure there is a ScoreManager in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            agent.destination = player.position;
        }
    }

    public void DamageTaken()
    {
        scoreManager.IncrementScore();
        Vector3 randomPosition = GetRandomPositionOnNavMesh();
        agent.Warp(randomPosition);


       
    }
    void OnCollisionEnter(Collision collision)
    {
        // Controleer of het object een schot is (je kunt dit aanpassen op basis van je project)
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("log1");
            // Verhoog de teller via de ScoreManager
            if (scoreManager != null)
            {
                Debug.Log("log2");
                scoreManager.IncrementScore();

            }

            // Verwijder of deactiveer het doelwit na een hit, als dat gewenst is
            Destroy(gameObject);
        }
    }

    Vector3 GetRandomPositionOnNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        bool found = false;

        int maxAttempts = 10;
        int attempts = 0;

        while (!found && attempts < maxAttempts)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;

            if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
            {
                randomPosition = hit.position;
                found = true;
            }

            attempts++;
        }

        if (!found)
        {
            Debug.LogWarning("Failed to find a valid position on the NavMesh.");
        }

        return randomPosition;
    }
}
