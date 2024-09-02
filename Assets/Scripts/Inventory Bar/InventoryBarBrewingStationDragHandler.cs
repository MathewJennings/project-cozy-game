using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBarBrewingStationDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject gameObjectToDrag; // if null, this object doesn't support dragging

    private static GameObject draggingObject;

    private InventoryItem inventoryItem;

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameObjectToDrag != null)
        {
            Canvas canvas = GetComponentInParent<Canvas>();
            draggingObject = Instantiate(gameObjectToDrag, canvas.transform);
            draggingObject.transform.position = Input.mousePosition;
            CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggingObject.transform.Translate(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UnrevealedIngredientDropHandler dropHandler = UnrevealedIngredientDropHandler.GetCurrentlyHovered();
        if (dropHandler != null)
        {
            Ingredient unrevealedIngredient = dropHandler.GetUnrevealedIngredient();
            if (unrevealedIngredient == inventoryItem)
            {
                Debug.Log("Successful drag of " + inventoryItem.name);
                dropHandler.RevealIngredient();
            } else if (unrevealedIngredient != null)
            {
                Debug.Log("required ingredient " + unrevealedIngredient.name);
            }
        }
        Destroy(draggingObject);
    }
}
