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
    private GameObject turnToNextPageButton;

    [SerializeField]
    private GameObject turnToPreviousPageButton;

    private int currentPageNumber;
    private GameObject instantiatedLeftRecipe;
    private GameObject instantiatedRightRecipe;

    // Start is called before the first frame update
    void Start()
    {
        currentPageNumber = 0;
        UpdateRenderedPages();
    }

    public void TurnToNextPage()
    {
        currentPageNumber++;
        UpdateRenderedPages();
    }

    public void TurnToPreviousPage()
    {
        currentPageNumber--;
        UpdateRenderedPages();
    }

    private void UpdateRenderedPages()
    {
        CleanupCurrentRecipes();
        UpdateLeftPage();
        UpdateRightPage();
        UpdateNextPageButton();
        UpdatePreviousPageButton();
    }

    private void CleanupCurrentRecipes()
    {
        if (instantiatedLeftRecipe != null)
        {
            Destroy(instantiatedLeftRecipe);
        }
        if (instantiatedRightRecipe != null)
        {
            Destroy(instantiatedRightRecipe);
        }
    }

    private void UpdateLeftPage()
    {
        List<Recipe> unlockedRecipes = recipeBookSO.GetUnlockedRecipes();
        int indexOfLeftPage = 2 * currentPageNumber;
        if (indexOfLeftPage < unlockedRecipes.Count)
        {
            Recipe leftRecipe = unlockedRecipes[indexOfLeftPage];
            instantiatedLeftRecipe = Instantiate(leftRecipe.recipePagePrefab, leftPage.transform);
        }
    }

    private void UpdateRightPage()
    {
        List<Recipe> unlockedRecipes = recipeBookSO.GetUnlockedRecipes();
        int indexOfRightPage = 2 * currentPageNumber + 1;
        if (indexOfRightPage < unlockedRecipes.Count)
        {
            Recipe rightRecipe = unlockedRecipes[indexOfRightPage];
            instantiatedRightRecipe = Instantiate(rightRecipe.recipePagePrefab, rightPage.transform);
        }
    }

    private void UpdateNextPageButton()
    {
        List<Recipe> unlockedRecipes = recipeBookSO.GetUnlockedRecipes();
        if (unlockedRecipes.Count >= (currentPageNumber + 1) * 2)
        {
            turnToNextPageButton.SetActive(true);
        } else
        {
            turnToNextPageButton.SetActive(false);
        }
    }

    private void UpdatePreviousPageButton()
    {
        if (currentPageNumber > 0)
        {
            turnToPreviousPageButton.SetActive(true);
        } else
        {
            turnToPreviousPageButton.SetActive(false);
        }
    }
}
