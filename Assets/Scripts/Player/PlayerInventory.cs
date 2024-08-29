using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IPauseObserver
{
    [SerializeField]
    private Inventory inventoryOnGameLoad;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private int inventorySize = 11;
    
    private int selectedIndex = 0;

    private void Start()
    {
        inventory.Clear();
        for (int i = 0; i < inventoryOnGameLoad.Count(); i++)
        {
            inventory.AddItem(inventoryOnGameLoad.Get(i));
        }
        FindObjectOfType<GamePauser>().RegisterObserver(this);
    }

    private void OnDestroy()
    {
        GamePauser gamePauser = FindObjectOfType<GamePauser>();
        if (gamePauser != null)
        {
            gamePauser.DeregisterObserver(this);
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

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            selectedIndex = mod(selectedIndex - 1, inventorySize);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            selectedIndex = mod(selectedIndex + 1, inventorySize);
        }
    }

    private int mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }

    public void NotifyGamePaused()
    {
        this.enabled = false;
    }

    public void NotifyGameResumed()
    {
        this.enabled = true;
    }
}
