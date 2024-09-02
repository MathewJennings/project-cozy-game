using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotEquipper : MonoBehaviour, IPointerClickHandler
{
    private PlayerInventory playerInventory;
    private InventoryItem inventoryItem;

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
    }

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        playerInventory.Equip(inventoryItem);
    }
}
