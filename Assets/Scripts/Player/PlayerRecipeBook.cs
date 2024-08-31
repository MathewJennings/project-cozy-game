using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecipeBook : MonoBehaviour
{

    [SerializeField]
    private RecipeBook recipeBookSO;

    [SerializeField]
    private GameObject recipeBook;
    //TODO will need to clean up how this script finds the recipe book game object once we start building more scenes...

    private int currentPageNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<Recipe> unlockedRecipes = recipeBookSO.GetUnlockedRecipes();
        int indexOfLeftPage = 2 * currentPageNumber;
        int indexOfRightPage = 2 * currentPageNumber + 1;
        if (indexOfLeftPage < unlockedRecipes.Count)
        {
            Recipe leftRecipe = unlockedRecipes[indexOfLeftPage];
            Instantiate(leftRecipe.recipePagePrefab, recipeBook.transform.Find("Left Page").transform);
        }
        if (indexOfRightPage < unlockedRecipes.Count)
        {
            Recipe rightRecipe = unlockedRecipes[indexOfRightPage];
            Instantiate(rightRecipe.recipePagePrefab, recipeBook.transform.Find("Right Page").transform);
        }
    }
}
