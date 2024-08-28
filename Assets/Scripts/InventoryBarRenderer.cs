using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBarRenderer : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField]
    private GameObject inventorySlot;

    private void Start()
    {
        for (int i = 0; i < playerInventory.GetInventorySize(); i++)
        {
            GameObject newSlot = Instantiate(inventorySlot, this.transform);
            RectTransform rectTransform = newSlot.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(10 + 170 * i, rectTransform.anchoredPosition.y);
        }
    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            RenderInventoryItem(i);
            RenderSelected(i);
        }
    }

    private void RenderInventoryItem(int i)
    {
        Inventory inventory = playerInventory.GetInventorySO();
        if (i < inventory.Count())
        {
            Inventory.InventoryItemAndAmount itemAndCount = inventory.Get(i);
            transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = itemAndCount.GetInventoryItem().uiSprite;

            TextMeshProUGUI amountText = transform.GetChild(i).Find("Quantity").GetComponent<TextMeshProUGUI>();
            amountText.gameObject.SetActive(true);
            amountText.text = itemAndCount.GetAmount().ToString();
        } else
        {
            transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = null;
            transform.GetChild(i).Find("Quantity").GetComponent<TextMeshProUGUI>().gameObject.SetActive(false);
        }
    }

    private void RenderSelected(int i)
    {
        transform.GetChild(i).Find("Selected").gameObject.SetActive(i == playerInventory.GetSelectedIndex());
    }
}
