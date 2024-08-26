using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour, IInteractable
{
    private static GameObject playerHeldObject = null;
    
    private bool isCurrentlyPickedUp = false;

    private void Update()
    {
        if (isCurrentlyPickedUp)
        {
            UpdateTransformRelativeToParent();
        }
    }

    public void Interact(GameObject player)
    {
        if (isCurrentlyPickedUp)
        {
            Drop(player);
        }
        else if (playerHeldObject == null)
        {
            Pickup(player);
        }
    }

    private void Drop(GameObject player)
    {
        transform.SetParent(null);
        transform.position = GetDropPosition(player);
        isCurrentlyPickedUp = false;
        playerHeldObject = null;
    }

    private Vector3 GetDropPosition(GameObject player)
    {
        Vector3 dropPosition = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y - 0.5f, player.transform.position.z);
        PlayerMover.FacingDirection facingDirection = player.GetComponent<PlayerMover>().GetFacingDirection();
        if (facingDirection == PlayerMover.FacingDirection.Left)
        {
            dropPosition.x = player.transform.position.x - 1.5f;
        }
        return dropPosition;
    }

    private void Pickup(GameObject player)
    {
        transform.SetParent(player.transform, false);
        UpdateTransformRelativeToParent();
        isCurrentlyPickedUp = true;
        playerHeldObject = this.gameObject;
    }

    private void UpdateTransformRelativeToParent()
    {
        transform.SetLocalPositionAndRotation(new Vector3(0f, 1.75f, 0f), Quaternion.identity);
    }
}
