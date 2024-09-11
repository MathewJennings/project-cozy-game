using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IngredientHolder))]
public class Roaster : MonoBehaviour, IIngredientAddRemoveObserver
{

    private bool isRoasting;

    public void ToggleRoasting() // Called by UI button press
    {
        isRoasting = !isRoasting;
        foreach (GameObject ingredientGameObject in GetComponent<IngredientHolder>().GetIngredientsGameObjects())
        {
            IngredientRoasting ingredientRoasting = ingredientGameObject.GetComponent<IngredientRoasting>();
            ingredientRoasting.SetIsRoasting(isRoasting);
        }
    }

    public void IngredientAdded(BrewingIngredient brewingIngredient)
    {
        IngredientRoasting ingredientRoasting = brewingIngredient.GetComponent<IngredientRoasting>();
        ingredientRoasting.SetRoastingBarActive(true);
        ingredientRoasting.SetIsRoasting(isRoasting);
    }

    public void IngredientRemoved(BrewingIngredient brewingIngredient)
    {
        IngredientRoasting ingredientRoasting = brewingIngredient.GetComponent<IngredientRoasting>();
        ingredientRoasting.SetRoastingBarActive(false);
        ingredientRoasting.SetIsRoasting(false);
    }
}
