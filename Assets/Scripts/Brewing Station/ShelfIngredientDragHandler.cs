using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfIngredientDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Bounds shelfBounds;
    private ShelfIngredientSpawner shelfIngredientSpawner;
    private Vector3 mouseClickOffset;

    public void SetShelf(GameObject shelf)
    {
        shelfBounds = shelf.GetComponent<BoxCollider2D>().bounds;
    }

    public void SetShelfIngredientSpawner(ShelfIngredientSpawner shelfIngredientSpawner)
    {
        this.shelfIngredientSpawner = shelfIngredientSpawner;
    }

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
        if (shelfBounds.Intersects(this.GetComponent<BoxCollider2D>().bounds))
        {
            shelfIngredientSpawner.AddShelfIngredient(this.gameObject);
        }
        else
        {
            shelfIngredientSpawner.RemoveShelfIngredient(this.gameObject);
        }
    }

    static bool BoundsIsEncapsulated(Bounds Encapsulator, Bounds Encapsulating)
    {
        return Encapsulator.Intersects(Encapsulating);
    }
}
