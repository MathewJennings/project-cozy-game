using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LevelBoundary : MonoBehaviour
{
    private Collider2D levelBoundaryCollider;

    void Awake()
    {
        levelBoundaryCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level Boundary Collision!");
        }
    }
}
