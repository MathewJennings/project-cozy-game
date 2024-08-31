using UnityEngine;

public abstract class Recipe : ScriptableObject
{
    public bool isUnlocked;
    public string title;
    public string text;
    public bool isRevealed;
    public string unrevealedTitle;
    public string unrevealedText;
    public GameObject recipePagePrefab;
}
