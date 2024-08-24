using System.Collections;
using System.Collections.Generic;
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
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out IWaterReceivable waterReceivable))
            {
                if (waterReceivable.IsActive())
                {
                    return waterReceivable;
                }
            }
        }
        return null;
    }
}
