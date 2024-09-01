using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRecipeChunk : MonoBehaviour
{
    [SerializeField]
    private Ingredient ingredient;

    public Ingredient GetIngredient()
    {
        return ingredient;
    }
}
