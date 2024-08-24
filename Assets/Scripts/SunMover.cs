using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SunMover : MonoBehaviour, ITimeObserver
{
    [SerializeField]
    private Transform sunrisePoint;
    [SerializeField]
    private Transform noonPoint;
    [SerializeField]
    private Transform sunsetPoint;
    
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

    public void NotifyNewDayStarted()
    {
        transform.position = sunrisePoint.position;
    }

    public void NotifyTimeOfDay(float percentDayElapsed)
    {
        Vector3 point1 = Vector3.Slerp(sunrisePoint.position, noonPoint.position, percentDayElapsed);
        Vector3 point2 = Vector3.Slerp(noonPoint.position, sunsetPoint.position, percentDayElapsed);
        gameObject.transform.position = Vector3.Slerp(point1, point2, percentDayElapsed);
    }
}
