using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IInteractable))]
public class InteractableManager : MonoBehaviour
{
    public void TriggerInteraction(GameObject player)
    {
        GetComponentInChildren<IInteractable>().Interact(player);
    }
}
