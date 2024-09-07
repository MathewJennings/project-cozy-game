using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BrewingIngredient brewingIngredient = collision.gameObject.GetComponent<BrewingIngredient>();
        if (brewingIngredient != null)
        {
            Destroy(brewingIngredient.gameObject);
        }
    }
}
