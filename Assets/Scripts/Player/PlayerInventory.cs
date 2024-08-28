using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;

    [SerializeField]
    private int inventorySize = 11;
    
    private int selectedIndex = 0;

    public Inventory GetPlayerInventory()
    {
        return playerInventory;
    }

    public int GetInventorySize()
    {
        return inventorySize;
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }

    public Inventory.InventoryItemAndAmount GetCurrentlySelectedItem()
    {
        if (selectedIndex > playerInventory.Count())
        {
            return null;
        }
        return playerInventory.Get(selectedIndex);
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            selectedIndex = mod(selectedIndex - 1, inventorySize);
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            selectedIndex = mod(selectedIndex + 1, inventorySize);
        }
    }

    int mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}
