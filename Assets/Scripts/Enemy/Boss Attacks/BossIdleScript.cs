using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleScript : StateMachineBehaviour
{
    public int Cooldown;
    public float Timer;
    public bool attackSet;
    public Enemy enemyScript;
    BossScript bs;

    int attack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackSet = false;
        bs = animator.gameObject.GetComponent<BossScript>();

        if (bs.lowHp == true)
        {
            Timer = 1.5f;
        }
        else
        {
            Timer = Cooldown;
        }
        enemyScript = animator.gameObject.GetComponent<Enemy>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackSet == false)
        {
            Timer = Timer - (1 * Time.deltaTime);

            if (Timer <= 0)
            {
                attackSet = true;
            }
        }

        if (attackSet == true)
        {

            if (bs.skullSummoned == false)
            {
                attack = 0;
            }

            if (bs.lowHp == true)
            {
                bs.skullSummoned = true;

                if (bs.skullSummoned == true && bs.hasSpawnedCenter == false)
                {
                    animator.SetBool("attackDone", true);
                    attack = 1;
                }
                else
                {
                    attack = 0;
                }           

            }

            animator.SetInteger("attack", attack);

        }
    }

}
