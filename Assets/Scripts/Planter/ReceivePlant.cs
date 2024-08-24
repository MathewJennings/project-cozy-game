using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ReceivePlant : MonoBehaviour, IPlantReceivable
{
    private bool hasPlant;

    public bool HasPlant()
    {
        return hasPlant;
    }

    void IPlantReceivable.ReceivePlant(GameObject plant)
    {
        if (!hasPlant)
        {
            Instantiate(plant, transform);
            hasPlant = true;
        }
    }
}
