using System.Collections.Generic;
using UnityEngine;

public abstract class Recipe : ScriptableObject
{
    public bool isUnlocked;
    public GameObject recipePagePrefab;
    public string title;
    public string text;
    public bool isRevealed;
    public List<Ingredient> ingredients;
    public List<bool> ingredientRevealed;
}
