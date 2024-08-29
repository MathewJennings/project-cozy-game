using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(IClickInteraction))]
public class PlayerInteractor : MonoBehaviour
{
    void Update()
    {
        HandleLeftClick();
        HandleE();
    }

    private void HandleLeftClick()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            IClickInteraction[] clickInteractions = GetComponents<IClickInteraction>();
            for (int i = 0; i < clickInteractions.Length; i++)
            {
                bool performedInteraction = clickInteractions[i].HandleLeftClick();
                if (performedInteraction)
                {
                    break;
                }
            }
        }
    }


    private void HandleE()
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
