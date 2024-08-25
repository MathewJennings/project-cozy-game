using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    List<string> inventory = new List<string>();

    public void AddToInventory(string newItemName)
    {
        inventory.Add(newItemName);
    }
}
