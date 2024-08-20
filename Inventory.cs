using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int NumberOfDiamonds { get; set; } = 0; // Start met 0 diamanten

    public UnityEvent<Inventory> onGoldCollected;

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        onGoldCollected.Invoke(this);
    }
}
