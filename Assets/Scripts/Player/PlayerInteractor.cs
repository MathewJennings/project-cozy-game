using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractableManager interactable = LookForNearbyInteractables();
            if (interactable == null)
            {
                return;
            }
            interactable.TriggerInteraction(this.gameObject);
        }
    }

    private InteractableManager LookForNearbyInteractables()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        var orderedByProximity = hitColliders.OrderBy(collider => (transform.position - collider.transform.position).sqrMagnitude).ToArray();

        foreach (Collider2D collider in orderedByProximity)
        {
            InteractableManager interactable = collider.gameObject.GetComponent<InteractableManager>();
            if (interactable != null)
            {
                return interactable;
            }
        }
        return null;
    }
}
