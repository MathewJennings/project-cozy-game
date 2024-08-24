using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlantGrowth))]
public class ReceiveWater : MonoBehaviour, IWaterReceivable, ITimeObserver
{
    [SerializeField]
    private Sprite wateredSprite;

    private Sprite unwateredSprite;
    private bool isWatered;

    void Start()
    {
        FindObjectOfType<TimeAdvancer>().RegisterObserver(this);
    }

    private void OnDestroy()
    {
        TimeAdvancer timeAdvancer = FindObjectOfType<TimeAdvancer>();
        if (timeAdvancer != null)
        {
            timeAdvancer.DeregisterObserver(this);
        }
    }

    public bool IsWatered()
    {
        return isWatered;
    }

   void IWaterReceivable.ReceiveWater()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        unwateredSprite = spriteRenderer.sprite;
        spriteRenderer.sprite = wateredSprite;
        isWatered = true;
    }

    public void NotifyNewDayStarted()
    {
        if (isWatered)
        {
            GetComponent<PlantGrowth>().NotifyShouldGrow();
        }
        isWatered = false;
        if (unwateredSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = unwateredSprite;
        }
    }

    public void NotifyTimeOfDay(float percentDayElapsed)
    {
        // Doesn't observe this
    }
}
