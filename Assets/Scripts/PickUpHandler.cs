using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour, IInteractable
{

    private bool canBePickedUp = true;
    private bool isCurrentlyPickedUp = false;

    private void Update()
    {
        if (isCurrentlyPickedUp)
        {
            UpdateTransformRelativeToParent();
        }
    }

    public bool CanBePickedUp()
    {
        return canBePickedUp;
    }

    public bool CanStoreItems()
    {
        return false;
    }

    public IInteractable Interact(GameObject holder)
    {
        if (canBePickedUp)
        {
            transform.SetParent(holder.transform, false);
            UpdateTransformRelativeToParent();
            canBePickedUp = false;
            isCurrentlyPickedUp = true;
            return this;
        }
        return null;
    }

    private void UpdateTransformRelativeToParent()
    {
        transform.SetLocalPositionAndRotation(new Vector3(0f, 1.75f, 0f), Quaternion.identity);
    }

    public void Drop(Vector3 dropPosition)
    {
        transform.SetParent(null);
        transform.position = dropPosition;
        canBePickedUp = true;
        isCurrentlyPickedUp = false;
    }
}
