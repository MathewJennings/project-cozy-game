using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ShelfIngredientDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ShelfIngredientSpawner shelfIngredientSpawner;
    private Bounds shelfBounds;
    private Vector3 mouseClickOffset;

    public void SetShelfIngredientSpawner(ShelfIngredientSpawner shelfIngredientSpawner)
    {
        this.shelfIngredientSpawner = shelfIngredientSpawner;
        shelfBounds = shelfIngredientSpawner.GetShelfBackground().GetComponent<BoxCollider2D>().bounds;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        mouseClickOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        GetComponent<BoxCollider2D>().enabled = false;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        rigidbody2D.velocity = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(eventData.position) + mouseClickOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        GetComponent<BoxCollider2D>().enabled = true;
        if (shelfBounds.Intersects(this.GetComponent<BoxCollider2D>().bounds))
        {
            shelfIngredientSpawner.AddShelfIngredient(this.gameObject);
        }
        else
        {
            shelfIngredientSpawner.RemoveShelfIngredient(this.gameObject);
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    static bool BoundsIsEncapsulated(Bounds Encapsulator, Bounds Encapsulating)
    {
        return Encapsulator.Intersects(Encapsulating);
    }
}
