using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlantHarvester: MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            IHarvestable plant = LookForNearbyHarvestables();
            if (plant != null)
            {
                GameObject harvested = plant.Harvest();
                if (harvested != null)
                {
                    Crop crop = plant.getCrop();
                   GetComponent<PlayerInventory>().GetInventorySO().AddItem(crop, 1);
                }
            }
        }
    }

    private IHarvestable LookForNearbyHarvestables()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            IHarvestable harvestable = collider.gameObject.GetComponentInChildren<IHarvestable>();
            if (harvestable != null && harvestable.IsHarvestable())
            {
                return harvestable;
            }
        }
        return null;
    }
}
