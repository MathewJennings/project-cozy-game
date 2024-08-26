using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlantHarvester: MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            IHarvestable plant = LookForNearbyHarvestables();
            if (plant != null)
            {
                GameObject harvested = plant.Harvest();
                if (harvested != null)
                {
                    //TODO GetComponent<PlayerInventory>().GetPlayerInventory().AddItem(harvested.name);
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
