using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public static string INSIDE_OVEN_LAYER = "Inside Oven";
    public static string DEFAULT_LAYER = "Default";

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

    public void InsertTray() // Called by UI button press
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
        if (!isSlerping)
        {
            return;
        }
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

    private void StartBaking()
    {
        tray.layer = LayerMask.NameToLayer(INSIDE_OVEN_LAYER);
        foreach (GameObject gameObject in ingredientHolder.GetIngredientsGameObjects())
        {
            gameObject.GetComponent<IngredientBaking>().StartBaking();
        }
    }

    private void StopBaking()
    {
        tray.layer = LayerMask.NameToLayer(DEFAULT_LAYER);
        foreach (GameObject gameObject in ingredientHolder.GetIngredientsGameObjects())
        {
            gameObject.GetComponent<IngredientBaking>().StopBaking();
        }
    }
}
