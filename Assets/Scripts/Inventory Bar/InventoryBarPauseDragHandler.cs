using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBarPauseDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPauseObserver
{
    [SerializeField]
    private GameObject gameObjectToDrag; // if null, this object doesn't support dragging

    private static GameObject draggingObject;

    private InventoryItem inventoryItem;
    private bool gamePaused;

    void Start()
    {
        FindObjectOfType<GamePauser>().RegisterObserver(this);
    }

    private void OnDestroy()
    {
        GamePauser gamePauser = FindObjectOfType<GamePauser>();
        if (gamePauser != null)
        {
            gamePauser.DeregisterObserver(this);
        }
    }

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gamePaused && gameObjectToDrag != null)
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
        if (gamePaused)
        {
            draggingObject.transform.Translate(eventData.delta);
        }
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
            }
        }
        Destroy(draggingObject);
    }

    public void NotifyGamePaused()
    {
        gamePaused = true;
    }

    public void NotifyGameResumed()
    {
        gamePaused = false;
    }
}
