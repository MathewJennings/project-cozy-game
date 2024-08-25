using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    /**
     * Returns the IInteractable that will be interacted with up by the actor
     */
    public IInteractable Interact(GameObject actor);
    public bool CanBePickedUp();
    public void Drop(Vector3 dropPosition);
    public bool CanStoreItems();

}
