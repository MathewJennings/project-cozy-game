using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBarDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPauseObserver
{
    [SerializeField]
    private GameObject gameObjectToDrag; // if null, this object doesn't support dragging

    private static GameObject draggingObject;

    void Start()
    {
        FindObjectOfType<GamePauser>().RegisterObserver(this);
        this.enabled = false;
    }

    private void OnDestroy()
    {
        GamePauser gamePauser = FindObjectOfType<GamePauser>();
        if (gamePauser != null)
        {
            gamePauser.DeregisterObserver(this);
        }
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
        InventoryItem requiredItem = UnknownRecipeTextDropHandler.GetRequiredItem();
        Debug.Log("required item " + requiredItem.name);
        Destroy(draggingObject);
    }

    public void NotifyGamePaused()
    {
        this.enabled = true;
    }

    public void NotifyGameResumed()
    {
        this.enabled = false;
    }
}
