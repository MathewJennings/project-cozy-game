using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnknownRecipeTextDropHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private InventoryItem unknownItem;

    [SerializeField]
    private List<GameObject> selectedHighlightingObjects;

    private static UnknownRecipeTextDropHandler hoverTarget;

    public static InventoryItem GetRequiredItem() { return hoverTarget.unknownItem; }

    private void Start()
    {
        selectedHighlightingObjects.ForEach(gameObject => gameObject.SetActive(false));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverTarget = this;
        selectedHighlightingObjects.ForEach(gameObject => gameObject.SetActive(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverTarget == this)
        {
            hoverTarget = null;
            selectedHighlightingObjects.ForEach(gameObject => gameObject.SetActive(false));
        }
    }
}
