using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBookManager : MonoBehaviour
{

    [SerializeField]
    private RecipeBook recipeBookSO;

    [SerializeField]
    private GameObject leftPage;

    [SerializeField]
    private GameObject rightPage;

    [SerializeField]
    private RecipeBookState recipeBookState;

    // Start is called before the first frame update
    void Start()
    {
        List<Recipe> unlockedRecipes = recipeBookSO.GetUnlockedRecipes();
        int indexOfLeftPage = 2 * recipeBookState.currentPageNumber;
        int indexOfRightPage = 2 * recipeBookState.currentPageNumber + 1;
        if (indexOfLeftPage < unlockedRecipes.Count)
        {
            Recipe leftRecipe = unlockedRecipes[indexOfLeftPage];
            Instantiate(leftRecipe.recipePagePrefab, leftPage.transform);
        }
        if (indexOfRightPage < unlockedRecipes.Count)
        {
            Recipe rightRecipe = unlockedRecipes[indexOfRightPage];
            Instantiate(rightRecipe.recipePagePrefab, rightPage.transform);
        }
    }
}
