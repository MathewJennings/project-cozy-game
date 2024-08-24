using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PlantWaterer : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            IWaterReceivable plant = LookForNearbyPlants();
            if (plant != null)
            {
                plant.ReceiveWater();
            }
        }
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
