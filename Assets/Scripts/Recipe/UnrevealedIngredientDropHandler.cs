using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnrevealedIngredientDropHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject selectedHighlightingObject;

    private static UnrevealedIngredientDropHandler currentlyHovered;

    private Recipe recipeSO;
    private RecipePageSetter recipePageSetter;
    private Ingredient unrevealedIngredient;

    public static UnrevealedIngredientDropHandler GetCurrentlyHovered()
    {
        return currentlyHovered;
    }

    public void SetRecipe(Recipe recipe)
    {
        recipeSO = recipe;
    }

    public void SetRecipePageSetter(RecipePageSetter recipePageSetter)
    {
        this.recipePageSetter = recipePageSetter;
    }

    public void SetUnrevealedIngredient(Ingredient unrevealedIngredient)
    {
        this.unrevealedIngredient = unrevealedIngredient;
    }

    public Ingredient GetUnrevealedIngredient()
    {
        return unrevealedIngredient;
    }

    public void RevealIngredient()
    {
        int revealedIndex = recipeSO.ingredients.IndexOf(unrevealedIngredient);
        recipeSO.ingredientRevealed[revealedIndex] = true;
        gameObject.GetComponent<Image>().sprite = unrevealedIngredient.uiSprite;
        selectedHighlightingObject.SetActive(false);
    }

    private void Start()
    {
        selectedHighlightingObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int index = recipeSO.ingredients.IndexOf(unrevealedIngredient);
        if (!recipeSO.ingredientRevealed[index])
        {
            currentlyHovered = this;
            selectedHighlightingObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentlyHovered == this)
        {
            currentlyHovered = null;
            selectedHighlightingObject.SetActive(false);
        }
    }
}
