using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlantGrowth : MonoBehaviour, IHarvestable
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

    private void UpdateGrowthStage(GrowthStage newGrowthStage)
    {
        currentGrowthStage = newGrowthStage;
        spriteRenderer.sprite = sprites[(int)currentGrowthStage];
    }

    public bool IsHarvestable()
    {
        return currentGrowthStage == GrowthStage.Harvestable;
    }

    public void NotifyShouldGrow()
    {
        UpdateGrowthStage(IsHarvestable() ? currentGrowthStage : currentGrowthStage + 1);
    }

    public GameObject Harvest()
    {
        if (IsHarvestable())
        {
            UpdateGrowthStage(GrowthStage.Plant);
            return gameObject;
        }
        return null;
    }
}
