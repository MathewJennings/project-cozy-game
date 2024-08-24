using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlantGrowth : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    enum GrowthStage { Seed, SmallSapling, BigSapling, Plant, Harvestable}

    private GrowthStage currentGrowthStage;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateGrowthStage(GrowthStage.Seed);
    }

    public void NotifyShouldGrow()
    {
        UpdateGrowthStage(currentGrowthStage < GrowthStage.Harvestable ? currentGrowthStage + 1 : currentGrowthStage);
    }

    private void UpdateGrowthStage(GrowthStage newGrowthStage)
    {
        currentGrowthStage = newGrowthStage;
        spriteRenderer.sprite = sprites[(int)currentGrowthStage];
    }
}
