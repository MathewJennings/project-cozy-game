using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IngredientDragHandler))]
public class BrewingIngredient : MonoBehaviour
{
    public Ingredient ingredient;

    [SerializeField]
    private GameObject spriteGameObject;

    [SerializeField]
    private GameObject roastingBarBackground;
    
    [SerializeField]
    private GameObject roastingBarFill;

    [SerializeField]
    private GameObject roastedLine;

    [SerializeField]
    private GameObject burntLine;

    private static Color UNDER_ROASTED_COLOR = new Color32(0xE2, 0xBA, 0x04, 0xFF);
    private static Color ROASTED_COLOR = new Color32(0x06, 0x70, 0x00, 0xFF);
    private static Color BURNT_COLOR = new Color32(0xA7, 0x00, 0x00, 0xFF);

    private RectTransform roastingBarFillRectTransform;
    private Image roastingBarFillImage;
    private float roastedPercentage;
    private float burntPercentage;

    private void Start()
    {
        roastingBarBackground.SetActive(false);
        roastingBarFillRectTransform = roastingBarFill.GetComponent<RectTransform>();
        roastingBarFillImage = roastingBarFill.GetComponent<Image>();
    }

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

    public void SetRoastingBarActive(bool isActive)
    {
        roastingBarBackground.SetActive(isActive);
    }

    public void SetRoastingBarPercentage(float roastingBarPercentage)
    {
        float roastingDecimal = roastingBarPercentage / 100;
        float clampedDecimal = Mathf.Clamp(roastingDecimal, 0, 1);
        roastingBarFillRectTransform.sizeDelta = new Vector2(clampedDecimal, roastingBarFillRectTransform.sizeDelta.y);
        if (clampedDecimal < roastedPercentage)
        {
            roastingBarFillImage.color = UNDER_ROASTED_COLOR;
        }
        else if (clampedDecimal < burntPercentage)
        {
            roastingBarFillImage.color = ROASTED_COLOR;
        }
        else
        {
            roastingBarFillImage.color = BURNT_COLOR;
        }
    }

    public void SetRoastedPercentage(float roastedPercentage)
    {
        this.roastedPercentage = roastedPercentage;
        Vector2 position = roastedLine.GetComponent<RectTransform>().anchoredPosition;
        roastedLine.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.roastedPercentage, position.y);
    }

    public void SetBurntPercentage(float burntPercentage)
    {
        this.burntPercentage = burntPercentage;
        Vector2 position = burntLine.GetComponent<RectTransform>().anchoredPosition;
        burntLine.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.burntPercentage, position.y);
    }
}
