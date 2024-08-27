using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DryingRack : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Sprite emptySprite;

    [SerializeField]
    private Sprite filledSprite;

    [SerializeField]
    private GreenTeaLeaves greenTeaLeaves;

    [SerializeField]
    private DriedGreenTeaLeaves driedGreenTeaLeaves;


    private bool isFilled = false;

    public void Interact(GameObject player)
    {
        Inventory playerInventory = player.GetComponent<PlayerInventory>().GetPlayerInventory();
        
        if (isFilled)
        {
            playerInventory.AddItem(driedGreenTeaLeaves, 1);
            GetComponent<SpriteRenderer>().sprite = emptySprite;
            isFilled = false; 
        }
        else
        {
            if (playerInventory.Contains(greenTeaLeaves, 1))
            {
                playerInventory.RemoveItem(greenTeaLeaves, 1);
                GetComponent<SpriteRenderer>().sprite = filledSprite;
                isFilled = true;
            }
        }
    }
}
