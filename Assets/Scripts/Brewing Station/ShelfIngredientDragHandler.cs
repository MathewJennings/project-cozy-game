using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfIngredientDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 mouseClickOffset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseClickOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(eventData.position) + mouseClickOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
