using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBarRenderer : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory playerInventory;

    private int selectedIndex = 0;

    void Update()
    {
        UpdateSelectedIndex();
        for (int i = 0; i < transform.childCount; i++)
        {
            RenderInventoryItem(i);
            RenderSelected(i);
        }
    }

    private void UpdateSelectedIndex()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            selectedIndex = mod(selectedIndex - 1, transform.childCount);
        } else if (Input.mouseScrollDelta.y > 0)
        {
            selectedIndex = mod(selectedIndex + 1, transform.childCount);
        }
    }

    int mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }

    private void RenderInventoryItem(int i)
    {
        Inventory inventory = playerInventory.GetPlayerInventory();
        if (i < inventory.Count())
        {
            Inventory.InventoryItemAndAmount itemAndCount = inventory.Get(i);
            transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = itemAndCount.GetInventoryItem().uiSprite;

            TextMeshProUGUI amountText = transform.GetChild(i).Find("Quantity").GetComponent<TextMeshProUGUI>();
            amountText.gameObject.SetActive(true);
            amountText.text = itemAndCount.GetAmount().ToString();
        } else
        {
            transform.GetChild(i).Find("Quantity").GetComponent<TextMeshProUGUI>().gameObject.SetActive(false);
        }
    }

    private void RenderSelected(int i)
    {
        transform.GetChild(i).Find("Selected").gameObject.SetActive(i == selectedIndex);
    }
}
