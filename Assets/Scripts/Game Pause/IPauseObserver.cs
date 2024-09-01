using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPauseObserver
{
    void NotifyGamePaused();

    void NotifyGameResumed();
}