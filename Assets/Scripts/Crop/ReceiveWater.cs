using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CropGrowth))]
public class ReceiveWater : MonoBehaviour, IWaterReceivable, ITimeObserver
{

    private bool isWatered;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        FindObjectOfType<TimeAdvancer>().RegisterObserver(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        isWatered = true;
        // Darken the sprite because it is wet
        spriteRenderer.color = new Color(0.75f, 0.75f, 0.75f);
    }

    public void NotifyNewDayStarted()
    {
        if (isWatered)
        {
            GetComponent<CropGrowth>().NotifyShouldGrow();
            isWatered = false;
            // Brighten the sprite because it is dry
            spriteRenderer.color = Color.white;
        }
    }

    public void NotifyTimeOfDay(float percentDayElapsed)
    {
        // Doesn't observe this
    }
}
