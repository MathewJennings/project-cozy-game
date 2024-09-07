using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngredientHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject ingredientsHolderGameObject;

    private List<GameObject> ingredientGameObjects;

    private void Start()
    {
        ingredientGameObjects = new();
    }

    public List<GameObject> GetIngredientsGameObjects()
    {
        return ingredientGameObjects;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BrewingIngredient brewingIngredient = collision.gameObject.GetComponent<BrewingIngredient>();
        if (brewingIngredient == null)
        {
            return;
        }
        
        brewingIngredient.transform.parent = ingredientsHolderGameObject.transform;
        GameObject ingredientGameObject = brewingIngredient.gameObject;
        if (!ingredientGameObjects.Contains(ingredientGameObject))
        {
            ingredientGameObjects.Add(ingredientGameObject);
        }
        ingredientGameObject.GetComponent<IngredientRoasting>().SetRoastingBarActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        BrewingIngredient brewingIngredient = collision.gameObject.GetComponent<BrewingIngredient>();
        if (brewingIngredient == null)
        {
            return;
        }

        brewingIngredient.transform.parent = null;
        GameObject ingredientGameObject = brewingIngredient.gameObject;
        if (ingredientGameObjects.Contains(ingredientGameObject))
        {
            ingredientGameObjects.Remove(ingredientGameObject);
        }
        ingredientGameObject.GetComponent<IngredientRoasting>().SetRoastingBarActive(false);
    }
}
