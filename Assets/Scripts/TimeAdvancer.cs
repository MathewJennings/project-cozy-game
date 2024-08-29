using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TimeAdvancer : MonoBehaviour, IPauseObserver
{
    [SerializeField]
    private float dayLengthInSeconds;

    private float elapsedDayTime;
    private int day = 0;
    
    private readonly List<ITimeObserver> observers = new();

    public void RegisterObserver(ITimeObserver newObserver)
    {
        observers.Add(newObserver);
    }

    public void DeregisterObserver(ITimeObserver observer)
    {
        observers.Remove(observer);
    }

    void Start()
    {
        StartNewDay();
        FindObjectOfType<GamePauser>().RegisterObserver(this);
    }

    private void OnDestroy()
    {
        GamePauser gamePauser = FindObjectOfType<GamePauser>();
        if (gamePauser != null)
        {
            gamePauser.DeregisterObserver(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedDayTime > dayLengthInSeconds)
        {
            StartNewDay();
        }
        AdvanceCurrentDay();
    }

    private void StartNewDay()
    {
        day++;
        elapsedDayTime = 0f;
        observers.ForEach(observer => observer.NotifyNewDayStarted());
    }

    private void AdvanceCurrentDay()
    {
        elapsedDayTime += Time.deltaTime;
        float percentDayElapased = elapsedDayTime / dayLengthInSeconds;
        observers.ForEach(observer => observer.NotifyTimeOfDay(percentDayElapased));
    }

    public void NotifyGamePaused()
    {
        this.enabled = false;
    }

    public void NotifyGameResumed()
    {
        this.enabled = true;
    }
}
