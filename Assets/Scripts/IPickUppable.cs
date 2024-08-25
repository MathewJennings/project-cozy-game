using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickuppable
{
    public bool CanBePickedUp();
    public bool IsCurrentlyPickedUp();

    /**
     * Returns the IPickuppable that will be picked up by the holder
     */
    public IPickuppable Pickup(GameObject holder);
    public void Drop(Vector3 dropPosition);

}
