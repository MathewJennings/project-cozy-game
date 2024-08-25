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

    private bool isEmpty = true;

    public bool CanBePickedUp()
    {
        return false;
    }

    public bool CanStoreItems()
    {
        return isEmpty;
    }

    public IInteractable Interact(GameObject actor)
    {
        isEmpty = !isEmpty;
        if (isEmpty)
        {
            GetComponent<SpriteRenderer>().sprite = emptySprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = filledSprite;
        }
        return this;
    }

    public void Drop(Vector3 dropPosition)
    {
        throw new System.NotImplementedException();
    }
}
