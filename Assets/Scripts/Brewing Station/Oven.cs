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

    [SerializeField]
    private IngredientHolder ingredientHolder;

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
            StopBaking();
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
            Vector3 newPosition = Vector3.Slerp(startPosition, targetPosition, slerpPercentage);
            Vector3 delta = newPosition - tray.transform.position;
            tray.transform.position = newPosition;
            foreach (GameObject gameObject in ingredientHolder.GetIngredientsGameObjects())
            {
                gameObject.transform.Translate(delta);
            }
            if (slerpPercentage >= 1f)
            {
                isSlerping = false;
                isTrayInOven = !isTrayInOven;
                if (isTrayInOven)
                {
                    StartBaking();
                }
            }
        }
    }

    private void StartBaking()
    {
        foreach(GameObject gameObject in ingredientHolder.GetIngredientsGameObjects())
        {
            gameObject.GetComponent<IngredientBaking>().StartBaking();
        }
    }

    private void StopBaking()
    {
        foreach (GameObject gameObject in ingredientHolder.GetIngredientsGameObjects())
        {
            gameObject.GetComponent<IngredientBaking>().StopBaking();
        }
    }
}
