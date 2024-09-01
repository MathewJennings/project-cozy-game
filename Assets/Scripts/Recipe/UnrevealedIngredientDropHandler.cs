using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnrevealedIngredientDropHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private InventoryItem unrevealedItem;

    [SerializeField]
    private List<GameObject> selectedHighlightingObjects;

    private static UnrevealedIngredientDropHandler hoverTarget;

    public void SetUnrevealedItem(InventoryItem unrevealedItem)
    {
        this.unrevealedItem = unrevealedItem;
    }

    public static InventoryItem GetRequiredItem()
    {
        if (hoverTarget == null)
        {
            return null;
        }
        return hoverTarget.unrevealedItem;
    }

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
