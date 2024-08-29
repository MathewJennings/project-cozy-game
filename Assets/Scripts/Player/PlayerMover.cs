using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour, IPauseObserver
{
    [SerializeField]
    private float speedMultiplier = 1f;
    private FacingDirection facingDirection;

    public enum FacingDirection { Left, Right }

    public FacingDirection GetFacingDirection()
    {
        return facingDirection;
    }

    void Start()
    {
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
            facingDirection = FacingDirection.Left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            translationVector += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            translationVector += Vector3.right;
            facingDirection = FacingDirection.Right;
        }
        gameObject.transform.position += translationVector.normalized * speedMultiplier * Time.deltaTime;
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
