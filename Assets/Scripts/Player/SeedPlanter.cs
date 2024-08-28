using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class SeedPlanter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            InventoryItem currentItem = GetComponent<PlayerInventory>().GetCurrentlySelectedItem().GetInventoryItem();
            if (currentItem is not Seed)
            {
                return;
            }

            IPlantReceivable planter = LookForNearbyPlanters();
            if (planter == null)
            {
                return;
            }
            PlantSeed(currentItem as Seed, planter);
        }
    }

    private void PlantSeed(Seed seed, IPlantReceivable planter)
    {
        GetComponent<PlayerInventory>().GetInventorySO().RemoveItem(seed, 1);
        planter.ReceivePlant(seed.cropPrefab);
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
