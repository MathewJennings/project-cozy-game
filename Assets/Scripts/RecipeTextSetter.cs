using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeTextSetter : MonoBehaviour
{
    [SerializeField]
    private Recipe recipeSO;

    [SerializeField]
    private TextMeshProUGUI recipeTitle;
    
    [SerializeField]
    private TextMeshProUGUI recipeText;

    void Start()
    {
        recipeTitle.text = recipeSO.isRevealed ? recipeSO.title.Replace("\\n", "\n") : recipeSO.unrevealedTitle.Replace("\\n", "\n");
        recipeText.text = recipeSO.isRevealed ? recipeSO.text.Replace("\\n", "\n") : recipeSO.unrevealedText.Replace("\\n", "\n");
    }
}
