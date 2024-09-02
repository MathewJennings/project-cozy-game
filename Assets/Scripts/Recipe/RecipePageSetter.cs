using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePageSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject ingredientImagePrefab;

    [SerializeField]
    private Recipe recipeSO;

    [SerializeField]
    private TextMeshProUGUI recipeTitle;

    [SerializeField]
    private TextMeshProUGUI recipeIngredientsLabel;

    [SerializeField]
    private GameObject ingredientsSection;

    [SerializeField]
    private TextMeshProUGUI recipeText;

    [SerializeField]
    private GameObject hiddenRecipeChunks;

    private static Color transparentGrey = new(.41f, .41f, .41f, .77f);

    public void RevealIngredient(Ingredient ingredient)
    {
        for (int i = 0; i < hiddenRecipeChunks.transform.childCount; i++)
        {
            GameObject chunkGameObject = hiddenRecipeChunks.transform.GetChild(i).gameObject;
            HiddenRecipeChunk hiddenRecipeChunk = chunkGameObject.GetComponent<HiddenRecipeChunk>();
            if (hiddenRecipeChunk.GetIngredient() == ingredient)
            {
                hiddenRecipeChunk.RevealText();
            }
        }
    }

    void Start()
    {
        SetText();
        SetIngredients();
        SetHiddenRecipeChunks();
    }

    private void SetText()
    {

        if (recipeSO.isUnlocked)
        {
            recipeTitle.text = recipeSO.title.Replace("\\n", "\n");
            recipeText.text = recipeSO.text.Replace("\\n", "\n");

            recipeTitle.color = Color.black;
            recipeIngredientsLabel.color = Color.black;
            recipeText.color = Color.black;
        }
        else
        {
            recipeTitle.text = Regex.Replace(recipeSO.title, "[^ ]", "?");
            recipeText.text = Regex.Replace(recipeSO.text, "[^ ]", "?");

            recipeTitle.color = transparentGrey;
            recipeIngredientsLabel.color = transparentGrey;
            recipeText.color = transparentGrey;
        }
    }

    private void SetIngredients()
    {
        for(int i = 0; i < recipeSO.ingredients.Count; i++)
        {
            Ingredient ingredient = recipeSO.ingredients[i];
            bool ingredientRevealed = recipeSO.ingredientRevealed[i];

            GameObject ingredientImage = Instantiate(ingredientImagePrefab, ingredientsSection.transform);
            ingredientImage.GetComponent<Image>().sprite = ingredientRevealed ? ingredient.uiSprite : ingredient.unidentifiedUiSprite;
            
            RectTransform rectTransform = ingredientImage.GetComponent<RectTransform>();
            float width = rectTransform.rect.width;
            rectTransform.anchoredPosition = new Vector2((10 + width) * i, rectTransform.anchoredPosition.y);

            UnrevealedIngredientDropHandler unrevealedIngredientDropHandler = ingredientImage.GetComponent<UnrevealedIngredientDropHandler>();
            unrevealedIngredientDropHandler.SetUnrevealedIngredient(ingredient);
            unrevealedIngredientDropHandler.SetRecipe(recipeSO);
            unrevealedIngredientDropHandler.SetRecipePageSetter(this);
        }
    }

    private void SetHiddenRecipeChunks()
    {
        for (int i = 0; i < hiddenRecipeChunks.transform.childCount; i++)
        {
            GameObject chunkGameObject = hiddenRecipeChunks.transform.GetChild(i).gameObject;
            HiddenRecipeChunk hiddenRecipeChunk = chunkGameObject.GetComponent<HiddenRecipeChunk>();
            Ingredient ingredient = hiddenRecipeChunk.GetIngredient();
            int index = recipeSO.ingredients.IndexOf(ingredient);
            if (recipeSO.ingredientRevealed[index])
            {
                hiddenRecipeChunk.RevealText();
            }
            else
            {
                hiddenRecipeChunk.HideText();
            }
        }
    }
}
