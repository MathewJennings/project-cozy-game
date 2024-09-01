using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour
{
    private bool isGamePaused;
    private readonly List<IPauseObserver> observers = new();

    public void RegisterObserver(IPauseObserver newObserver)
    {
        observers.Add(newObserver);
    }

    public void DeregisterObserver(IPauseObserver observer)
    {
        observers.Remove(observer);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        observers.ForEach(observer => observer.NotifyGamePaused());
    }

    private void ResumeGame()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        observers.ForEach(observer => observer.NotifyGameResumed());
    }
}
