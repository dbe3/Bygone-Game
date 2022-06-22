using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;
    public float HorizontalMove = 0f;
    public Animator anim;
    public float RunSpeed = 40f;
    public bool jump;

    [SerializeField] LayerMask GroundLayer;

    public bool isGrounded = false;
    public Transform GroundCheckCollider;
    public float groundCheckRadius;
    public bool canMove;

    [Header("Swipe Variables")]
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;
    int dir = 0;
    void Update()
    {
        Swipe();

        if (canMove == true)
        {
            HorizontalMove = dir * RunSpeed;
        }

        GroundCheck();

        if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded)
            {
                jump = true;
                anim.SetBool("isJumping", true);
            }
        }


    }

    public void Jump()
    {
        if (isGrounded)
        {
            jump = true;
            anim.SetBool("isJumping", true);
        }
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    //Going Left
                    dir = -1;
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    //Going Right
                    dir = 1;
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    //Going up
                    Jump();
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    dir = 0;
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                //Tap lang
            }
        }
    }

    void FixedUpdate()
    {
        playerController.Move(HorizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, groundCheckRadius, GroundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
