using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float speedMultiplier = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 translationVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            translationVector += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            translationVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            translationVector += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            translationVector += Vector3.right;
        }
        gameObject.transform.position += translationVector.normalized * speedMultiplier * Time.deltaTime;
    }
}
