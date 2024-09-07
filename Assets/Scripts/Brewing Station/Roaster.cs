using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IngredientHolder))]
public class Roaster : MonoBehaviour
{

    private bool isRoasting;

    public void ToggleRoasting()
    {
        isRoasting = !isRoasting;
        foreach (GameObject ingredientGameObject in GetComponent<IngredientHolder>().GetIngredientsGameObjects())
        {
            IngredientRoasting ingredientRoasting = ingredientGameObject.GetComponent<IngredientRoasting>();
            ingredientRoasting.SetIsRoasting(isRoasting);
        }
    }
}
