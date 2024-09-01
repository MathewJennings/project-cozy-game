using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBarDragHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPauseObserver
{
    [SerializeField]
    private GameObject gameObjectToDrag; // if null, this object doesn't support dragging

    private static GameObject draggingObject;
    private static GameObject hoverTarget;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverTarget = this.gameObject;
        Debug.Log("hover target " + hoverTarget);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverTarget == this.gameObject)
        {
            hoverTarget = null;
        }
        Debug.Log("hover target " + hoverTarget);
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
