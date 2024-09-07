using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IngredientHolder))]
public class Roaster : MonoBehaviour
{
    [SerializeField]
    private float roastingSpeed = 1f;

    [SerializeField]
    private float roastedPercentage = .65f;

    [SerializeField]
    private float burntPercentage = .85f;

    private bool isRoasting;
    private float roastingPercentage;

    public void ToggleRoasting()
    {
        isRoasting = !isRoasting;
        if (isRoasting)
        {
            roastingPercentage = 0;
        }
        foreach (GameObject ingredientGameObject in GetComponent<IngredientHolder>().GetIngredientsGameObjects())
        {
            IngredientRoasting ingredientRoasting = ingredientGameObject.GetComponent<IngredientRoasting>();
            ingredientRoasting.SetRoastingBarActive(isRoasting);
            ingredientRoasting.SetRoastingBarPercentage(roastingPercentage);
            ingredientRoasting.SetRoastedPercentage(roastedPercentage);
            ingredientRoasting.SetBurntPercentage(burntPercentage);
        }
    }

    private void Update()
    {
        if (isRoasting)
        {
            roastingPercentage += Time.deltaTime * roastingSpeed;
            foreach (GameObject ingredientGameObject in GetComponent<IngredientHolder>().GetIngredientsGameObjects())
            {
                IngredientRoasting ingredientRoasting = ingredientGameObject.GetComponent<IngredientRoasting>();
                ingredientRoasting.SetRoastingBarPercentage(roastingPercentage);
            }
        }
    }
}
