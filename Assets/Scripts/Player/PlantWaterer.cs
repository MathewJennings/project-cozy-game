using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlantWaterer : MonoBehaviour, IClickInteraction
{

    public bool HandleLeftClick()
    {
        Inventory.InventoryItemAndAmount currentlySelected = GetComponent<PlayerInventory>().GetCurrentlySelectedItem();
        if (currentlySelected == null)
        {
            return false;
        }

        InventoryItem currentItem = currentlySelected.GetInventoryItem();
        if (currentItem is not WateringCan)
        {
            return false;
        }

        IWaterReceivable plant = LookForNearbyPlants();
        if (plant == null)
        {
            return false;
        }

        plant.ReceiveWater();
        return true;
    }

    private IWaterReceivable LookForNearbyPlants()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            IWaterReceivable waterReceivable = collider.gameObject.GetComponentInChildren<IWaterReceivable>();
            if (waterReceivable != null && !waterReceivable.IsWatered())
            {
                return waterReceivable;
            }
        }
        return null;
    }
}
