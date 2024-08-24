using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ReceiveWater : MonoBehaviour, IWaterReceivable, ITimeObserver
{
    [SerializeField]
    private Sprite wateredSprite;

    private Sprite unwateredSprite;

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

    public bool IsActive()
    {
        return isActiveAndEnabled;
    }

    void IWaterReceivable.ReceiveWater()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        unwateredSprite = spriteRenderer.sprite;
        spriteRenderer.sprite = wateredSprite;
    }

    public void NotifyNewDayStarted()
    {
        if (unwateredSprite !=  null)
        {
            GetComponent<SpriteRenderer>().sprite = unwateredSprite;
        }
    }

    public void NotifyTimeOfDay(float percentDayElapsed)
    {
        // Doesn't observe this
    }
}
