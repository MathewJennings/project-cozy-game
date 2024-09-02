using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrewingStationInteraction : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject brewingInterface;

    private bool isBrewingInterfaceEnabled;
    private InventoryBarBrewingStationDragHandler[] inventoryBarBrewingStationDragHandlers;

    void Start()
    {
        brewingInterface.SetActive(false);
    }

    public void Interact(GameObject player)
    {
        isBrewingInterfaceEnabled = !isBrewingInterfaceEnabled;
        brewingInterface.SetActive(isBrewingInterfaceEnabled);
        LazyLoadDragHandlers();
        foreach (InventoryBarBrewingStationDragHandler dragHandler in inventoryBarBrewingStationDragHandlers)
        {
            dragHandler.enabled = isBrewingInterfaceEnabled;
        }
    }

    private void LazyLoadDragHandlers()
    {
        inventoryBarBrewingStationDragHandlers ??= GameObject.FindObjectsOfType<InventoryBarBrewingStationDragHandler>();
    }
}
