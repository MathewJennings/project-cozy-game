using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientRoasting : IngredientBarManipulator
{
    public void SetIsRoasting(bool isRoasting)
    {
        isBarFilling = isRoasting;
    }

    public void SetRoastingBarActive(bool isActive)
    {
        SetBarActive(isActive);
    }
    private new void Start()
    {
        UNDER_TARGET_BAR_COLOR = new Color32(0xE2, 0xBA, 0x04, 0xFF);
        TARGET_BAR_COLOR = new Color32(0x06, 0x70, 0x00, 0xFF);
        TARGET_INGREDIENT_COLOR = new Color32(0xCF, 0xB3, 0x76, 0xFF);
        OVERDONE_BAR_COLOR = new Color32(0xA7, 0x00, 0x00, 0xFF);
        OVERDONE_INGREDIENT_COLOR = new Color32(0x89, 0x6E, 0x34, 0xFF);
        base.Start();
    }
}
