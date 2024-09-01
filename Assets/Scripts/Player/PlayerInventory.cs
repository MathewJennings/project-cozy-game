using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Inventory inventoryOnGameLoad;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private int inventorySize = 12;
    
    private int selectedIndex = 0;

    private void Start()
    {
        inventory.Clear();
        for (int i = 0; i < inventoryOnGameLoad.Count(); i++)
        {
            inventory.AddItem(inventoryOnGameLoad.Get(i));
        }
    }

    public Inventory GetInventorySO()
    {
        return inventory;
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
        if (selectedIndex > inventory.Count())
        {
            return null;
        }
        return inventory.Get(selectedIndex);
    }

    public void Equip(InventoryItem inventoryItem)
    {
        if (!inventory.Contains(inventoryItem))
        {
            return;
        }
        int index = inventory.IndexOf(inventoryItem);
        selectedIndex = index;
    }

    void Update()
    {
        CheckMouseScroll();
        CheckNumberKeysDown();
    }

    private void CheckMouseScroll()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            selectedIndex = Mod(selectedIndex - 1, inventorySize);
        } else if (Input.mouseScrollDelta.y < 0)
        {
            selectedIndex = Mod(selectedIndex + 1, inventorySize);
        }
    }

    private void CheckNumberKeysDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedIndex = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedIndex = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedIndex = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selectedIndex = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selectedIndex = 8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedIndex = 9;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            selectedIndex = 10;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            selectedIndex = 11;
        }

    }

    private int Mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}
