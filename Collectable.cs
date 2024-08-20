using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void Start()
    {
        // Eventuele initiële setup
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered: " + other.gameObject.name);
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            Debug.Log("Inventory found. Collecting diamond.");
            inventory.DiamondCollected();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No Inventory component found on the object.");
        }
    }
}
