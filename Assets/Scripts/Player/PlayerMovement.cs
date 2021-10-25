using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController playerController;
    float HorizontalMove = 0f;
    public Animator anim;
    public float RunSpeed = 40f;
    bool jump;

    // Update is called once per frame
    void Update()
    {

        HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        playerController.Move(HorizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
