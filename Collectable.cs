using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    FirstPersonController firstPersonController;
    private void Start()
    {
        firstPersonController = FindAnyObjectByType<FirstPersonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if(inventory != null)
        {
            Debug.Log("collected");
            inventory.DiamondCollected();
            gameObject.SetActive(false);
            firstPersonController.m_MyAudioSource.Play();
        }
    }
}
