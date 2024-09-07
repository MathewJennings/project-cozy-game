using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientRoasting : MonoBehaviour
{
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
