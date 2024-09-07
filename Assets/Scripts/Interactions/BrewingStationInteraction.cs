using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        
    }
}
