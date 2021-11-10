using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    PlayerHealth ph;
    PlayerController pc;
    PlayerMovement pm;
    Rigidbody2D rb;

    public float kbPowerX;
    public float kbPowerY;
    public bool knockback;
    float runSpeed;
    int jumpForce;
    public float kbDuration;
    float timer;
    public void Start()
    {
        ph = GetComponent<PlayerHealth>();
        pc = GetComponent<PlayerController>();
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();

        runSpeed = pm.RunSpeed;
        jumpForce = pc.JumpForce;

        timer = kbDuration;
    }

    public void Update()
    {
        if (knockback == true)
        {
            GetComponent<PlayerMovement>().canMove = false;
            timer = timer - Time.deltaTime;

            if (timer <= 0)
            {
                GetComponent<PlayerMovement>().canMove = true;               
                timer = kbDuration;
                knockback = false;
                pm.RunSpeed = runSpeed;
                pc.JumpForce = jumpForce;
            }
        }
    }

    public void Knockback(GameObject enemy)
    {
        knockback = true;
        rb.velocity = new Vector2((kbPowerX * pc.direction * -1) * Time.deltaTime, kbPowerY * Time.deltaTime);
        GetComponent<PlayerMovement>().RunSpeed = 0f;
        pc.JumpForce = 0;
    }
}
