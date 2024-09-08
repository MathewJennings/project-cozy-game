using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBaking : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public void StartBaking()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new(originalColor.r, originalColor.g, originalColor.b, 0.5f);
    }

    public void StopBaking()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new(originalColor.r, originalColor.g, originalColor.b, 1f);
    }
}
