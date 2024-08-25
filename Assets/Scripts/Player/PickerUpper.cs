using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerMover))]
public class PickerUpper : MonoBehaviour
{
    private IPickuppable currentlyHeldItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentlyHeldItem == null)
            {
                PerformPickup();
            }
            else
            {
                PerformDrop();
            }
        }
    }

    private void PerformPickup()
    {
        IPickuppable pickup = LookForNearbyPickUppables();
        if (pickup != null)
        {
            currentlyHeldItem = pickup.Pickup(this.gameObject);
        }
    }

    private IPickuppable LookForNearbyPickUppables()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            IPickuppable pickup = collider.gameObject.GetComponentInChildren<IPickuppable>();
            if (pickup != null && pickup.CanBePickedUp())
            {
                return pickup;
            }
        }
        return null;
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
