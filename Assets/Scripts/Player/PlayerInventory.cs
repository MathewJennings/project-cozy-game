using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;

    public Inventory GetPlayerInventory()
    {
        return playerInventory;
    }
}
