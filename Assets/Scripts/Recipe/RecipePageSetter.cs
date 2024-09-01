using System.Collections;
using System.Collections.Generic;
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

    private static Color transparentGrey = new(.41f, .41f, .41f, .77f);

    void Start()
    {
        SetText();
        SetIngredients();
    }

    private void SetText()
    {
        recipeTitle.text = recipeSO.isRevealed ? recipeSO.title.Replace("\\n", "\n") : recipeSO.unrevealedTitle.Replace("\\n", "\n");
        recipeText.text = recipeSO.isRevealed ? recipeSO.text.Replace("\\n", "\n") : recipeSO.unrevealedText.Replace("\\n", "\n");

        if (recipeSO.isUnlocked)
        {
            recipeTitle.color = Color.black;
            recipeIngredientsLabel.color = Color.black;
            recipeText.color = Color.black;
        } else
        {
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
            
            GameObject ingredientImage = Instantiate(ingredientImagePrefab, ingredientsSection.transform);
            ingredientImage.GetComponent<Image>().sprite = recipeSO.isRevealed ? ingredient.uiSprite : ingredient.unidentifiedUiSprite;
            
            RectTransform rectTransform = ingredientImage.GetComponent<RectTransform>();
            float width = rectTransform.rect.width;
            rectTransform.anchoredPosition = new Vector2((10 + width) * i, rectTransform.anchoredPosition.y);
        }
    }
}
