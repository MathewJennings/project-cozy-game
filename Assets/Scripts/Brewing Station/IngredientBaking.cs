using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientBaking : IngredientBarManipulator
{
    [SerializeField]
    private IngredientDragHandler ingredientDragHandler;

    public void StartBaking()
    {
        isBarFilling = true;
        SetBarActive(true);
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new(originalColor.r, originalColor.g, originalColor.b, 0.5f);
        ingredientDragHandler.enabled = false;
        gameObject.layer = LayerMask.NameToLayer(Oven.INSIDE_OVEN_LAYER);
    }

    public void StopBaking()
    {
        isBarFilling = false;
        SetBarActive(false);
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = new(originalColor.r, originalColor.g, originalColor.b, 1f);
        ingredientDragHandler.enabled = true;
        gameObject.layer = LayerMask.NameToLayer(Oven.DEFAULT_LAYER);
    }

    private new void Start()
    {
        UNDER_TARGET_BAR_COLOR = new Color32(0xE2, 0xBA, 0x04, 0xFF);
        TARGET_BAR_COLOR = new Color32(0x06, 0x70, 0x00, 0xFF);
        TARGET_INGREDIENT_COLOR = new Color32(0xFC, 0xCD, 0x9E, 0xFF);
        OVERDONE_BAR_COLOR = new Color32(0xA7, 0x00, 0x00, 0xFF);
        OVERDONE_INGREDIENT_COLOR = new Color32(0x6A, 0x56, 0x43, 0xFF);
        base.Start();
    }
}
