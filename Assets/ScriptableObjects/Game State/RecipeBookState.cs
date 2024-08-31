using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipeBookState", menuName = "Game State/Recipe Book State")]
public class RecipeBookState : ScriptableObject
{
    public int currentPageNumber;
}
