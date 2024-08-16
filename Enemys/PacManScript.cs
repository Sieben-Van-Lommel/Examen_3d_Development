using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PacManScript : MonoBehaviour
{
    public Transform player;
    public Transform fleeArea;
    public NavMeshAgent agent;
    private GameManager gameManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = FindAnyObjectByType<GameManager>();

        agent.destination = fleeArea.position;
    }
    void Update()
    {
        if (!gameManager.isPaused)
        {
            if (agent.remainingDistance < 0.01f)
            {
                agent.destination = player.position;
                agent.speed *= 4;

            }
        }
                  
    }
   
    public void DamageTaken()
    {
        Vector3 randomPosition = GetRandomPositionOnNavMesh();
        agent.Warp(randomPosition);

    }
    Vector3 GetRandomPositionOnNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        bool found = false;

        // Attempt to find a valid position on the NavMesh within the maximum attempts
        int maxAttempts = 10;
        int attempts = 0;

        while (!found && attempts < maxAttempts)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f; // Adjust the radius as needed
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
