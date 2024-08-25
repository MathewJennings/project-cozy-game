using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent (typeof(PlayerInventory))]
public class PlayerInteractor : MonoBehaviour
{
    private IInteractable currentlyHeldItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentlyHeldItem == null)
            {
                Interact();
            }
            else
            {
                PerformDrop();
            }
        }
    }

    private void Interact()
    {
        IInteractable interactable = LookForNearbyInteractables();
        if (interactable == null)
        {
            return;
        }
        if (interactable.CanBePickedUp())
        {
            PerformPickup(interactable);
        }
        else if(interactable.CanStoreItems())
        {
            PerformStore(interactable);
        }
    }

    private IInteractable LookForNearbyInteractables()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            IInteractable interactable = collider.gameObject.GetComponentInChildren<IInteractable>();
            if (interactable != null)
            {
                return interactable;
            }
        }
        return null;
    }

    private void PerformPickup(IInteractable interactable)
    {
        currentlyHeldItem = interactable.Interact(this.gameObject);
    }

    private void PerformStore(IInteractable interactable)
    {
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (inventory.GetSize() > 0) {
            inventory.RemoveFromInventory(inventory.Get(0));
            interactable.Interact(this.gameObject);
        }
    }

    private void PerformDrop()
    {
        Vector3 dropPosition = new Vector3(transform.position.x + 1.5f, transform.position.y - 0.5f, transform.position.z);
        PlayerMover.FacingDirection facingDirection = GetComponent<PlayerMover>().GetFacingDirection();
        if (facingDirection == PlayerMover.FacingDirection.Left)
        {
            dropPosition.x = transform.position.x - 1.5f;
        }
        currentlyHeldItem.Drop(dropPosition);
        currentlyHeldItem = null;
    }
}
