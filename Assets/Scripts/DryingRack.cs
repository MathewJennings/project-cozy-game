using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DryingRack : MonoBehaviour, ITimeObserver
{
    [SerializeField]
    private Sprite emptySprite;

    [SerializeField]
    private Sprite filledSprite;


    private Crop dryingCrop = null;
    private bool isCurrentlyDrying = false;
    private bool hasCompletedDrying = false;

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

    public bool IsCurrentlyDrying()
    {
        return isCurrentlyDrying;
    }

    public bool HasCompletedDrying()
    {
        return hasCompletedDrying;
    }

    public void StartDrying(Crop crop)
    {
        dryingCrop = crop;
        isCurrentlyDrying = true;
        hasCompletedDrying = false;
        GetComponent<SpriteRenderer>().sprite = filledSprite;
    }

    public void NotifyNewDayStarted()
    {
        if (isCurrentlyDrying)
        {
            hasCompletedDrying = true;
        }
    }

    public void NotifyTimeOfDay(float percentDayElapsed)
    {
        // Not observed
    }

    /// Returns the Dried Crop
    public Crop TakeDriedCrop()
    {
        Crop driedCrop = dryingCrop.driedCrop;
        dryingCrop = null;
        isCurrentlyDrying = false;
        hasCompletedDrying = false;
        GetComponent<SpriteRenderer>().sprite = emptySprite;
        return driedCrop;
    }
}
