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
        recipeTitle.text = recipeSO.title;
        recipeText.text = recipeSO.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
