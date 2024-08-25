using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    List<string> inventory = new List<string>();

    public int GetSize()
    {
        return inventory.Count;
    }

    public void AddToInventory(string newItemName)
    {
        inventory.Add(newItemName);
    }

    public string Get(int index)
    {
        return inventory[index];
    }

    public string RemoveFromInventory(string itemToRemove)
    {
        string itemFound = inventory.Find(item => item.Equals(itemToRemove));
        inventory.Remove(itemFound);
        return itemFound;
    }
}
