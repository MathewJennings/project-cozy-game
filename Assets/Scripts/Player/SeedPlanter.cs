using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IPlantReceivable planter = LookForNearbyPlanters();
            if (planter != null)
            {
                planter.ReceivePlant();
            }
        }
    }

    private IPlantReceivable LookForNearbyPlanters()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out IPlantReceivable plantReceivable))
            {
                return plantReceivable;
            }
        }
        return null;
    }
}
