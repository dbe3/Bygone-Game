using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpForce;
    public float MovementSmoothing;
    public Transform GroundCheck;
    public Transform CeilingCheck;

    public GameObject Knife;

    private Rigidbody2D playerRb;
    private Vector3 m_Velocity = Vector3.zero;
    public Transform ShootLocation;

    public Animator anim;
    Vector3 facingDirection;

    public bool facingRight;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void Move(float move, bool jump)
    {

        //Movement 2d
        Vector3 targetVelocity = new Vector2(move * 10f, playerRb.velocity.y);
        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);
        
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (move != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    
        //Jump
        if (jump)
        {
            playerRb.AddForce(new Vector2(0f, JumpForce));
        }
    }

    public void Attack()
    {
        GameObject projectile = Instantiate(Knife, ShootLocation.position, transform.rotation);
        anim.SetBool("isAttacking", true);
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    

}
