using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientRoasting : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject roastingBarBackground;

    [SerializeField]
    private GameObject roastingBarFill;

    [SerializeField]
    private GameObject roastedLine;

    [SerializeField]
    private GameObject burntLine;
    
    [SerializeField]
    private float roastingSpeed;

    [SerializeField]
    private float roastedPercentageMark;

    [SerializeField]
    private float burntPercentageMark;

    private static Color UNDER_ROASTED_BAR_COLOR = new Color32(0xE2, 0xBA, 0x04, 0xFF);
    private static Color ROASTED_BAR_COLOR = new Color32(0x06, 0x70, 0x00, 0xFF);
    private static Color ROASTED_INGREDIENT_COLOR = new Color32(0xFC, 0xCD, 0x9E, 0xFF);
    private static Color BURNT_BAR_COLOR = new Color32(0xA7, 0x00, 0x00, 0xFF);
    private static Color BURNT_INGREDIENT_COLOR = new Color32(0x6A, 0x56, 0x43, 0xFF);

    private bool isRoasting;
    private float roastingPercentage;

    private RectTransform roastingBarFillRectTransform;
    private Image roastingBarFillImage;
    
    public void SetIsRoasting(bool isRoasting)
    {
        this.isRoasting = isRoasting;
    }

    public void SetRoastingBarActive(bool isActive)
    {
        roastingBarBackground.SetActive(isActive);
    }

    public bool GetIsBurnt()
    {
        return roastingPercentage > burntPercentageMark;
    }

    public bool GetIsRoasted()
    {
        return roastingPercentage > roastedPercentageMark && !GetIsBurnt();
    }

    private void Start()
    {
        roastingBarFillRectTransform = roastingBarFill.GetComponent<RectTransform>();
        roastingBarFillImage = roastingBarFill.GetComponent<Image>();

        roastingPercentage = 0;
        SetRoastingBarPercentage();
        SetRoastingBarActive(false);

        InitializeLine(roastedLine, roastedPercentageMark);
        InitializeLine(burntLine, burntPercentageMark);
    }

    private void InitializeLine(GameObject line, float xPos)
    {
        Vector2 currPos = line.GetComponent<RectTransform>().anchoredPosition;
        line.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, currPos.y);
    }

    private void Update()
    {
        if (isRoasting)
        {
            roastingPercentage += Time.deltaTime * roastingSpeed;
            SetRoastingBarPercentage();
        }
    }

    private void SetRoastingBarPercentage()
    {
        float roastingDecimal = roastingPercentage / 100;
        float clampedDecimal = Mathf.Clamp(roastingDecimal, 0, 1);
        roastingBarFillRectTransform.sizeDelta = new Vector2(clampedDecimal, roastingBarFillRectTransform.sizeDelta.y);
        if (clampedDecimal < roastedPercentageMark)
        {
            roastingBarFillImage.color = UNDER_ROASTED_BAR_COLOR;
        }
        else if (clampedDecimal < burntPercentageMark)
        {
            roastingBarFillImage.color = ROASTED_BAR_COLOR;
            spriteRenderer.color = ROASTED_INGREDIENT_COLOR;
        }
        else
        {
            roastingBarFillImage.color = BURNT_BAR_COLOR;
            spriteRenderer.color = BURNT_INGREDIENT_COLOR;
        }
    }
}
