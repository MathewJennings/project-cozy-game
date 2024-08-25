using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
        if (isFilled)
        {
            playerInventory.AddToInventory("Dried Tea Leaves");
            GetComponent<SpriteRenderer>().sprite = emptySprite;
            isFilled = false; 
        }
        else
        {
            if (playerInventory.GetSize() > 0)
            {
                playerInventory.RemoveFromInventory(playerInventory.Get(0));
                GetComponent<SpriteRenderer>().sprite = filledSprite;
                isFilled = true;
            }
        }
    }
}
