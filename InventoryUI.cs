using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    void Start()
    {
        if (goldText == null)
        {
            goldText = GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateGoldText(Inventory inventory)
    {
        if (goldText != null)
        {
            goldText.text = inventory.NumberOfDiamonds.ToString();
        }
        else
        {
            Debug.LogError("goldText is not assigned.");
        }
    }
}
