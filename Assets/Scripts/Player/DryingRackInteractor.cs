using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class DryingRackInteractor : MonoBehaviour, IClickInteraction
{
    public bool HandleLeftClick()
    {
        DryingRack dryingRack = LookForNearbyDryingRacks();
        if (dryingRack == null)
        {
            return false;
        }

        if (dryingRack.HasCompletedDrying())
        {
            FinishDrying(dryingRack);
            return true;
        }

        Inventory.InventoryItemAndAmount currentlySelected = GetComponent<PlayerInventory>().GetCurrentlySelectedItem();
        if (currentlySelected == null)
        {
            return false;
        }

        InventoryItem currentItem = currentlySelected.GetInventoryItem();
        if (currentItem is not Crop || (currentItem as Crop).isDried)
        {
            return false;
        }

        if (!dryingRack.IsCurrentlyDrying())
        {
            StartDrying(currentItem as Crop, dryingRack);
            return true;
        }

        return false;
    }

    private DryingRack LookForNearbyDryingRacks()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            if (collider.gameObject.TryGetComponent(out DryingRack dryingRack))
            {
                return dryingRack;
            }
        }
        return null;
    }

    private void FinishDrying(DryingRack dryingRack)
    {
        Crop driedCrop = dryingRack.TakeDriedCrop();
        GetComponent<PlayerInventory>().GetInventorySO().AddItem(driedCrop, 1);
    }

    private void StartDrying(Crop crop, DryingRack dryingRack)
    {
        GetComponent<PlayerInventory>().GetInventorySO().RemoveItem(crop, 1);
        dryingRack.StartDrying(crop);
    }
}
