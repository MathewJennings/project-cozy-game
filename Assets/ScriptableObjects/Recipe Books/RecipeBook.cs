using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// this class represents the entire recipe book which is itself a list of ScriptableObjects
[CreateAssetMenu(fileName = "NewRecipeBook", menuName = "Recipe/New Recipe Book")]
public class RecipeBook : ScriptableObject
{
    [SerializeField]
    private List<Recipe> unlockedRecipes;

    public List<Recipe> GetUnlockedRecipes() { return unlockedRecipes; }
}
