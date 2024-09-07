using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ShelfIngredientDragHandler))]
public class BrewingIngredient : MonoBehaviour
{
    public Ingredient ingredient;

    [SerializeField]
    private GameObject spriteGameObject;

    [SerializeField]
    private GameObject roastingBar;

    private RectTransform roastingBarFillRectTransform;

    private void Start()
    {
        roastingBar.SetActive(false);
        GameObject roastingBarFill = roastingBar.transform.GetChild(0).gameObject;
        Debug.Log(roastingBarFill.name);
        roastingBarFillRectTransform = roastingBarFill.GetComponent<RectTransform>();
    }

    public void Initialize(Ingredient ingredient, ShelfIngredientSpawner shelfIngredientSpawner)
    {
        this.ingredient = ingredient;
        SpriteRenderer spriteRenderer = InitializeSprite(ingredient);
        InitializeScale(spriteRenderer, shelfIngredientSpawner.GetTargetSpriteSize());
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<ShelfIngredientDragHandler>().SetShelfIngredientSpawner(shelfIngredientSpawner);
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

    public void SetRoastingBarActive(bool isActive)
    {
        roastingBar.SetActive(isActive);
    }

    public void SetRoastingBarPercentage(float roastingBarPercentage)
    {
        float roastingDecimal = roastingBarPercentage / 100;
        float clampedDecimal = Mathf.Clamp(roastingDecimal, 0, 1);
        roastingBarFillRectTransform.sizeDelta = new Vector2(clampedDecimal, roastingBarFillRectTransform.sizeDelta.y);
    }
}
