using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRecipeChunk : MonoBehaviour
{
    [SerializeField]
    private GameObject revealedText;

    [SerializeField]
    private Ingredient ingredient;

    public Ingredient GetIngredient()
    {
        return ingredient;
    }

    public void RevealText()
    {
        revealedText.SetActive(true);
    }

    public void HideText()
    {
        revealedText.SetActive(false);
    }
}
