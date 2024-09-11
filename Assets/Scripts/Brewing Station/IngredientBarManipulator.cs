using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IngredientBarManipulator : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject barBackground;

    [SerializeField]
    private GameObject barFill;

    [SerializeField]
    private GameObject targetLine;

    [SerializeField]
    private GameObject overdoneLine;
    
    [SerializeField]
    private float barFillSpeed;

    [SerializeField]
    private float targetPercentageMark;

    [SerializeField]
    private float overdonePercentageMark;

    protected static Color UNDER_TARGET_BAR_COLOR;
    protected static Color TARGET_BAR_COLOR;
    protected static Color TARGET_INGREDIENT_COLOR;
    protected static Color OVERDONE_BAR_COLOR;
    protected static Color OVERDONE_INGREDIENT_COLOR;
    
    protected bool isBarFilling;
    private float barFillPercentage;

    private RectTransform barFillRectTransform;
    private Image barFillImage;

    public bool GetIsOverdone()
    {
        return barFillPercentage > overdonePercentageMark;
    }

    public bool GetIsComplete()
    {
        return barFillPercentage > targetPercentageMark && !GetIsOverdone();
    }

    protected void SetBarActive(bool isActive)
    {
        barBackground.SetActive(isActive);
    }

    protected void Start()
    {
        barFillRectTransform = barFill.GetComponent<RectTransform>();
        barFillImage = barFill.GetComponent<Image>();

        barFillPercentage = 0;
        SetBarPercentage();
        SetBarActive(false);

        InitializeLine(targetLine, targetPercentageMark);
        InitializeLine(overdoneLine, overdonePercentageMark);
    }

    private void InitializeLine(GameObject line, float xPos)
    {
        Vector2 currPos = line.GetComponent<RectTransform>().anchoredPosition;
        line.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, currPos.y);
    }

    private void Update()
    {
        if (isBarFilling)
        {
            bool wasOverdone = GetIsOverdone();
            bool wasComplete = GetIsComplete();
            barFillPercentage = Mathf.Clamp(barFillPercentage + Time.deltaTime * barFillSpeed, 0, 1);
            if (!wasOverdone && GetIsOverdone())
            {
                DarkenSpriteWithColor(spriteRenderer, OVERDONE_INGREDIENT_COLOR);
            }
            if (!wasComplete && GetIsComplete())
            {
                DarkenSpriteWithColor(spriteRenderer, TARGET_INGREDIENT_COLOR);
            }
            SetBarPercentage();
        }
    }

    private void DarkenSpriteWithColor(SpriteRenderer spriteRenderer, Color newColor)
    {
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = new Color(
            currentColor.r - (1 - newColor.r),
            currentColor.g - (1 - newColor.g),
            currentColor.b - (1 - newColor.b),
            currentColor.a - (1 - newColor.a)
        );
    }

    private void SetBarPercentage()
    {
        float clampedDecimal = Mathf.Clamp(barFillPercentage, 0, 1);
        barFillRectTransform.sizeDelta = new Vector2(clampedDecimal, barFillRectTransform.sizeDelta.y);
        if (GetIsOverdone())
        {
            barFillImage.color = OVERDONE_BAR_COLOR;
        }
        else if (GetIsComplete())
        {
            barFillImage.color = TARGET_BAR_COLOR;
        }
        else
        {
            barFillImage.color = UNDER_TARGET_BAR_COLOR;
        }
    }
}
