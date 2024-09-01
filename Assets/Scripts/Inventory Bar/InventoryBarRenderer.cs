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
            float width = rectTransform.rect.width;
            rectTransform.anchoredPosition = new Vector2(10 + width/2 + (10 + width)*i, rectTransform.anchoredPosition.y);
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
            int amount = itemAndCount.GetAmount();
            amountText.text = amount.ToString();
            amountText.gameObject.SetActive(amount > 1);
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
