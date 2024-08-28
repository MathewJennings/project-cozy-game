using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBarRenderer : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory playerInventory;

    void Update()
    {
        Inventory inventory = playerInventory.GetPlayerInventory();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < inventory.Count())
            {
                Inventory.InventoryItemAndAmount itemAndCount = inventory.Get(i);
                transform.GetChild(i).GetComponentInChildren<Image>().sprite = itemAndCount.GetInventoryItem().uiSprite;

                TextMeshProUGUI amountText = transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
                amountText.gameObject.SetActive(true);
                amountText.text = itemAndCount.GetAmount().ToString();
            }
            else
            {
                transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            }
        }
    }
}
