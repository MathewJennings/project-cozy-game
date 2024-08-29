using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// this class represents the entire inventory which is itself a list of ScriptableObjects
[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private List<InventoryItemAndAmount> inventoryItems;

    public void Clear()
    {
        inventoryItems.Clear();
    }

    public int Count()
    {
        return inventoryItems.Count;
    }

    public InventoryItemAndAmount Get(int index)
    {
        if (index >= inventoryItems.Count)
        {
            return null;
        }
        return inventoryItems[index];
    }

    public bool Contains(InventoryItem item)
    {
        return Contains(item, 1);
    }

    public bool Contains(InventoryItem item, int amount)
    {
        InventoryItemAndAmount found = inventoryItems.Find(itemAndAmount =>
            itemAndAmount.GetInventoryItem().Equals(item) && itemAndAmount.GetAmount() >= amount);
        return found != null;
    }

    public void AddItem(InventoryItemAndAmount item)
    {
        InventoryItemAndAmount deepCopy = new InventoryItemAndAmount(item.GetInventoryItem(), item.GetAmount());
        inventoryItems.Add(deepCopy);
    }

    public void AddItem(InventoryItem item)
    {
        AddItem(item, 1);
    }

    public void AddItem(InventoryItem item, int amount)
    {
        if (Contains(item, amount))
        {
            InventoryItemAndAmount existingStack = inventoryItems.Find(itemAndAmount => itemAndAmount.GetInventoryItem().Equals(item));
            existingStack.AddAmount(amount);
        }
        else
        {
            inventoryItems.Add(new InventoryItemAndAmount(item, amount));
        }
    }
    public void RemoveItem(InventoryItem item)
    {
        RemoveItem(item, 1);
    }

    public void RemoveItem(InventoryItem item, int amount)
    {
        if (Contains(item))
        {
            InventoryItemAndAmount existingStack = inventoryItems.Find(itemAndAmount => itemAndAmount.GetInventoryItem().Equals(item));
            existingStack.RemoveAmount(amount);
            if (existingStack.GetAmount() <= 0)
            {
                inventoryItems.Remove(existingStack);
            }
        }
    }

    [Serializable]
    public class InventoryItemAndAmount
    {
        [SerializeField]
        private InventoryItem inventoryItem;
        [SerializeField]
        private int amount;

        public InventoryItemAndAmount(InventoryItem inventoryItem, int amount)
        {
            this.inventoryItem = inventoryItem;
            this.amount = amount;
        }

        public InventoryItem GetInventoryItem() { return inventoryItem; }
        public int GetAmount() { return amount; }

        public void AddAmount(int amount)
        {
            this.amount += amount;
        }

        public void RemoveAmount(int amount)
        {
            this.amount -= amount;
        }
    }
}
