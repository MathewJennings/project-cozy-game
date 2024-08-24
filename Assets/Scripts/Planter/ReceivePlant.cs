using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ReceiveWater))]
public class ReceivePlant : MonoBehaviour, IPlantReceivable
{

    [SerializeField]
    private Sprite seededSprite;

    private bool hasPlant;

    void IPlantReceivable.ReceivePlant()
    {
        if (!hasPlant)
        {
            GetComponent<SpriteRenderer>().sprite = seededSprite;
            GetComponent<ReceiveWater>().enabled = true;
            hasPlant = true;
        }
    }
}
