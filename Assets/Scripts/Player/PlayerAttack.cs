using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController playerController;
    public Animator anim;

    public float AttackCooldown;
    float Timer;
    bool canAttack;

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                playerController.Attack();
                canAttack = false;
                Timer = AttackCooldown;
            }
        }

        if (!canAttack)
        {
            Timer = Timer - (1 * Time.deltaTime);

            if (Timer <= 0)
            {
                canAttack = true;
            }
        }
    }

    public void DoneAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
