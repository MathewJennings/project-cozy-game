using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ReceiveWater : MonoBehaviour, IWaterReceivable
{
    [SerializeField]
    private Sprite wateredSprite;

    public bool IsActive()
    {
        return isActiveAndEnabled;
    }

    void IWaterReceivable.ReceiveWater()
    {
        GetComponent<SpriteRenderer>().sprite = wateredSprite;
    }
}
