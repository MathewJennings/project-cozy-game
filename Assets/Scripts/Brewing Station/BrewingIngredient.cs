using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IngredientDragHandler))]
public class BrewingIngredient : MonoBehaviour
{
    public Ingredient ingredient;

    [SerializeField]
    private GameObject spriteGameObject;

    public void Initialize(Ingredient ingredient, ShelfIngredientSpawner shelfIngredientSpawner)
    {
        this.ingredient = ingredient;
        SpriteRenderer spriteRenderer = InitializeSprite(ingredient);
        InitializeScale(spriteRenderer, shelfIngredientSpawner.GetTargetSpriteSize());
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<IngredientDragHandler>().SetShelfIngredientSpawner(shelfIngredientSpawner);
    }

    private SpriteRenderer InitializeSprite(Ingredient ingredient)
    {
        SpriteRenderer spriteRenderer = spriteGameObject.GetComponent<SpriteRenderer>();
        Sprite sprite = ingredient.uiSprite;
        spriteRenderer.sprite = sprite;
        gameObject.name = sprite.name;
        return spriteRenderer;
    }

    private void InitializeScale(SpriteRenderer spriteRenderer, float targetSpriteSize)
    {
        float width = spriteRenderer.sprite.rect.width;
        float targetScale = targetSpriteSize / width;
        spriteGameObject.transform.localScale = new Vector3(targetScale, targetScale, 1f);
    }
}
