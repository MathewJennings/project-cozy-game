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
    
    [SerializeField]
    private float roastingSpeed = 10f;

    [SerializeField]
    private float roastedPercentageMark;

    [SerializeField]
    private float burntPercentageMark;

    private static Color UNDER_ROASTED_COLOR = new Color32(0xE2, 0xBA, 0x04, 0xFF);
    private static Color ROASTED_COLOR = new Color32(0x06, 0x70, 0x00, 0xFF);
    private static Color BURNT_COLOR = new Color32(0xA7, 0x00, 0x00, 0xFF);

    private bool isRoasting;
    private float roastingPercentage;

    private RectTransform roastingBarFillRectTransform;
    private Image roastingBarFillImage;

    public void SetIsRoasting(bool isRoasting)
    {
        this.isRoasting = isRoasting;
        roastingBarBackground.SetActive(isRoasting);
    }

    private void Start()
    {
        roastingBarBackground.SetActive(false);
        roastingBarFillRectTransform = roastingBarFill.GetComponent<RectTransform>();
        roastingBarFillImage = roastingBarFill.GetComponent<Image>();

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
            roastingBarFillImage.color = UNDER_ROASTED_COLOR;
        }
        else if (clampedDecimal < burntPercentageMark)
        {
            roastingBarFillImage.color = ROASTED_COLOR;
        }
        else
        {
            roastingBarFillImage.color = BURNT_COLOR;
        }
    }
}
