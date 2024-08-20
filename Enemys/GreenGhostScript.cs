using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GreenGhostScript : MonoBehaviour
{
    public float wanderRadius = 20f;
        
    private NavMeshAgent agent;
    private GameManager gameManager;
    private ScoreManager scoreManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = FindAnyObjectByType<GameManager>();
                
        SetNewDestination();
    }

    void Update()
    {

        if (!gameManager.isPaused)
        {
            
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                
                SetNewDestination();
            }
        }
    }
    public void DamageTaken()
    {
        scoreManager.IncrementScore();
        Vector3 randomPosition = GetRandomPositionOnNavMesh();
        agent.Warp(randomPosition);



    }

    void SetNewDestination()
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);

        agent.SetDestination(newPos);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
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
