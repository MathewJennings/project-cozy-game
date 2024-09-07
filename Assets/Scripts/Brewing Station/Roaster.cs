using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IngredientHolder))]
public class Roaster : MonoBehaviour
{
    [SerializeField]
    private float roastingSpeed = 1f;

    private bool isRoasting;
    private float roastingPercentage;

    public void ToggleRoasting()
    {
        isRoasting = !isRoasting;
        if (isRoasting)
        {
            roastingPercentage = 0;
        }
        foreach (BrewingIngredient brewingIngredient in GetComponent<IngredientHolder>().GetBrewingIngredients())
        {
            brewingIngredient.SetRoastingBarActive(isRoasting);
            brewingIngredient.SetRoastingBarPercentage(roastingPercentage);
        }
    }

    private void Update()
    {
        if (isRoasting)
        {
            roastingPercentage += Time.deltaTime * roastingSpeed;
            foreach (BrewingIngredient brewingIngredient in GetComponent<IngredientHolder>().GetBrewingIngredients())
            {
                brewingIngredient.SetRoastingBarPercentage(roastingPercentage);
            }
        }
    }
}
