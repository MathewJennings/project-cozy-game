using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantGrowth : MonoBehaviour
{
    enum GrowthStage { Seed, SmallSapling, BigSapling, Plant, Harvestable}

    private GrowthStage currentGrowthStage;
    private ReceiveWater receiveWater;

    void Start()
    {
        currentGrowthStage = GrowthStage.Seed;
        receiveWater = GetComponent<ReceiveWater>();
    }

    public void NotifyShouldGrow()
    {
        AdvanceGrowthStage();
    }

    private void AdvanceGrowthStage()
    {
        if (currentGrowthStage != GrowthStage.Harvestable)
        {
            currentGrowthStage++;
        }
    }
}
