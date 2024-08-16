using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateGoldText(Inventory inventory)
    {
        goldText.text = inventory.NumberOfDiamonds.ToString();
        
    }
}
