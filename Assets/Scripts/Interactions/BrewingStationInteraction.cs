using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingStationInteraction : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject brewingInterface;

    private bool isBrewingInterfaceEnabled;

    void Start()
    {
        brewingInterface.SetActive(false);
    }

    public void Interact(GameObject player)
    {
        isBrewingInterfaceEnabled = !isBrewingInterfaceEnabled;
        brewingInterface.SetActive(isBrewingInterfaceEnabled);
        InventoryBarBrewingStationDragHandler[] dragHandlers = GameObject.FindObjectsOfType<InventoryBarBrewingStationDragHandler>();
        foreach(InventoryBarBrewingStationDragHandler dragHandler in dragHandlers)
        {
            dragHandler.enabled = isBrewingInterfaceEnabled;
        }
    }
}
