using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField]
    private GameObject tray;

    [SerializeField]
    private Transform trayPointOut;

    [SerializeField]
    private Transform trayPointIn;

    private bool isTrayInOven;

    private bool isSlerping;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timeToSlerp = 0.5f;
    private float slerpPercentage;

    public void InsertTray()
    {
        if (isSlerping)
        {
            return;
        }
        isSlerping = true;
        slerpPercentage = 0f;
        if (isTrayInOven)
        {
            startPosition = trayPointIn.position;
            targetPosition = trayPointOut.position;
        }
        else
        {
            startPosition = trayPointOut.position;
            targetPosition = trayPointIn.position;
        }
    }

    private void Update()
    {
        if (isSlerping)
        {
            slerpPercentage += Time.deltaTime / timeToSlerp;
            tray.transform.position = Vector3.Lerp(startPosition, targetPosition, slerpPercentage);
            if (slerpPercentage >= 1f)
            {
                isTrayInOven = !isTrayInOven;
                isSlerping = false;
            }
        }
    }
}
