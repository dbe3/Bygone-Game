using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleScript : StateMachineBehaviour
{
    public int Cooldown;
    public float Timer;
    public bool attackSet;
    public Enemy enemyScript;
    public bool hpLow;
    public bool skullsSummoned;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackSet = false;
        Timer = Cooldown;
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

        if (enemyScript.Health <= enemyScript.Health / 2)
        {
            hpLow = true;
        }

        if (attackSet == true)
        {
            int attack = 0;
            animator.SetInteger("attack", attack);
        }
    }

}
