using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject planterPrefab;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(planterPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
