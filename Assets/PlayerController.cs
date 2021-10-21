using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpForce;
    public float MovementSmoothing;
    public Transform GroundCheck;
    public Transform CeilingCheck;

    private Rigidbody2D playerRb;
    private Vector3 m_Velocity = Vector3.zero;

    public Animator anim;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void Move(float move, bool jump)
    {

        //Movement 2d
        Vector3 targetVelocity = new Vector2(move * 10f, playerRb.velocity.y);

        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

        //Jump
        if (jump)
        {
            playerRb.AddForce(new Vector2(0f, JumpForce));
        }
    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
    }
}
