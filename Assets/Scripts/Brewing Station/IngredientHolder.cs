using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngredientHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject ingredientsGameObject;

    private List<BrewingIngredient> brewingIngredients;

    private void Start()
    {
        brewingIngredients = new();
    }

    public List<BrewingIngredient> GetBrewingIngredients()
    {
        return brewingIngredients;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BrewingIngredient brewingIngredient = collision.gameObject.GetComponent<BrewingIngredient>();
        if (brewingIngredient == null)
        {
            return;
        }
        
        brewingIngredient.transform.parent = ingredientsGameObject.transform;
        if (!brewingIngredients.Contains(brewingIngredient))
        {
            brewingIngredients.Add(brewingIngredient);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        BrewingIngredient brewingIngredient = collision.gameObject.GetComponent<BrewingIngredient>();
        if (brewingIngredient == null)
        {
            return;
        }

        brewingIngredient.transform.parent = null;
        if (brewingIngredients.Contains(brewingIngredient))
        {
            brewingIngredients.Remove(brewingIngredient);
        }
    }
}
