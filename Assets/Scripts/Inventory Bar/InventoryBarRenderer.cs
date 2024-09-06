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

    private List<Inventory.InventoryItemAndAmount> cachedInventory;
    private int cachedSelectedIndex;

    private void Start()
    {
        int inventorySize = playerInventory.GetInventorySize();
        cachedInventory = new List<Inventory.InventoryItemAndAmount>(inventorySize);
        cachedSelectedIndex = -1;
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject newSlot = Instantiate(inventorySlot, this.transform);
            RectTransform rectTransform = newSlot.GetComponent<RectTransform>();
            float width = rectTransform.rect.width;
            rectTransform.anchoredPosition = new Vector2(10 + width/2 + (10 + width)*i, rectTransform.anchoredPosition.y);
            cachedInventory.Add(null);
        }
        
    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            RenderInventoryItem(i);
        }
        int selectedIndex = playerInventory.GetSelectedIndex();
        if (selectedIndex != cachedSelectedIndex)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                RenderSelected(i, selectedIndex);
            }
            cachedSelectedIndex = selectedIndex;
        }
    }

    private void RenderInventoryItem(int i)
    {
        Transform inventorySlot = transform.GetChild(i);
        Inventory inventory = playerInventory.GetInventorySO();
        if (i < inventory.Count())
        {
            Inventory.InventoryItemAndAmount itemAndCount = inventory.Get(i);
            if (!itemAndCount.Equals(cachedInventory[i]))
            {
                SetInventorySlotItem(inventorySlot, itemAndCount.GetInventoryItem());
                SetInventorySlotAmount(inventorySlot, itemAndCount.GetAmount());
                cachedInventory[i] = new Inventory.InventoryItemAndAmount(itemAndCount);
            }
        }
        else
        {
            ClearInventorySlot(inventorySlot);
        }
    }

    private void SetInventorySlotItem(Transform inventorySlot, InventoryItem inventoryItem)
    {
        inventorySlot.Find("Image").GetComponent<Image>().sprite = inventoryItem.uiSprite;
        inventorySlot.GetComponent<InventorySlotEquipper>().SetInventoryItem(inventoryItem);
        inventorySlot.GetComponent<InventoryBarPauseDragHandler>().SetInventoryItem(inventoryItem);
    }

    private void SetInventorySlotAmount(Transform inventorySlot, int amount)
    {
        TextMeshProUGUI amountText = inventorySlot.Find("Quantity").GetComponent<TextMeshProUGUI>();
        amountText.text = amount.ToString();
        amountText.gameObject.SetActive(amount > 1);
    }

    private void ClearInventorySlot(Transform inventorySlot)
    {
        inventorySlot.Find("Image").GetComponent<Image>().sprite = null;
        inventorySlot.Find("Quantity").GetComponent<TextMeshProUGUI>().gameObject.SetActive(false);
    }

    private void RenderSelected(int i, int selectedIndex)
    {
        transform.GetChild(i).Find("Selected").gameObject.SetActive(i == selectedIndex);
    }
}
