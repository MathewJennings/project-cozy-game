using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBarBrewingStationDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPauseObserver
{
    [SerializeField]
    private GameObject gameObjectToDrag; // if null, this object doesn't support dragging

    private static GameObject draggingObject;

    private InventoryItem inventoryItem;
    private GameObject brewingInterface;

    private void Start()
    {
        // This script should be enabled by BrewingStationInteraction.cs
        this.enabled = false;
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

    public void SetBrewingInterface(GameObject brewingInterface)
    {
        this.brewingInterface = brewingInterface;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameObjectToDrag != null)
        {
            Canvas canvas = brewingInterface.GetComponent<Canvas>();
            draggingObject = Instantiate(gameObjectToDrag, canvas.transform);
            draggingObject.transform.position = Input.mousePosition;
            //CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
            //canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggingObject.transform.Translate(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //draggingObject.component
        //Rigidbody2D rigidbody2D = draggingObject.AddComponent<Rigidbody2D>();
        //rigidbody2D.gravityScale = 1;
        //BoxCollider2D boxCollider2D = draggingObject.AddComponent<BoxCollider2D>();
    }

    public void NotifyGamePaused()
    {
        this.enabled = false;
    }

    public void NotifyGameResumed()
    {
        this.enabled = true;
    }
}
