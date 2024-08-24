using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeObserver
{
    void NotifyNewDayStarted();

    void NotifyTimeOfDay(float percentDayElapsed);
}