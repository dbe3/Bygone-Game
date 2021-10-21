using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController playerController;
    public Animator anim;

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            playerController.Attack();
        }

    }

    public void DoneAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
