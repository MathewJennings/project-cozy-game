using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

[RequireComponent(typeof(SpriteRenderer))]
public class DryingRack : MonoBehaviour, IInteractable
{
    [SerializeField]
    Sprite emptySprite;

    [SerializeField]
    Sprite filledSprite;

    private bool isFilled = false;

    public void Interact(GameObject player)
    {
        Inventory playerInventory = player.GetComponent<PlayerInventory>().GetPlayerInventory();
        
        if (isFilled)
        {
            //TODO playerInventory.AddToInventory("Dried Tea Leaves");
            GetComponent<SpriteRenderer>().sprite = emptySprite;
            isFilled = false; 
        }
        else
        {
            if (playerInventory.Contains(new GreenTeaSeed(), 1))
            {
                playerInventory.RemoveItem(new GreenTeaSeed(), 1);
                GetComponent<SpriteRenderer>().sprite = filledSprite;
                isFilled = true;
            }
        }
    }
}
