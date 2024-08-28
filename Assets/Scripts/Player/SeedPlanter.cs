using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{
    [SerializeField]
    private GameObject cropPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IPlantReceivable planter = LookForNearbyPlanters();
            if (planter != null)
            {
                planter.ReceivePlant(cropPrefab);
            }
        }
    }

    private IPlantReceivable LookForNearbyPlanters()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            if (collider.gameObject.TryGetComponent(out IPlantReceivable plantReceivable))
            {
                if (!plantReceivable.HasPlant())
                {
                    return plantReceivable;
                }
            }
        }
        return null;
    }
}
