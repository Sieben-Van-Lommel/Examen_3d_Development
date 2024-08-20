using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedGhostScript : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        Vector3 randomPosition = GetRandomPositionOnNavMesh();
        agent.Warp(randomPosition);

        // Ensure the GameManager instance is available and update gold
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateGold();
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
