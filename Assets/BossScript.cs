using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Enemy enemyScript;
    public int attack;
    public bool searchAttack = true;
    Animator anim;
    public float direction;
    [Header("Timer")]
    public float Cooldown;
    public float currentTime;

    [Header("Boss Movelist")]
    public List<BossAttack> bossAttacks = new List<BossAttack>();

    void Start()
    {
        anim = GetComponent<Animator>();
        currentTime = Cooldown;
        direction = -1;
}

    void Update()
    {
        //Sprite Flip
        if (transform.position.x - enemyScript.Player.transform.position.x > 0 && !enemyScript.left)
        {
            enemyScript.Flip();
            direction = -1;
        }
        else if (transform.position.x - enemyScript.Player.transform.position.x < 0 && enemyScript.left)
        {
            enemyScript.Flip();
            direction = 1;
        }

        if (searchAttack == true)
        {
            attack = Random.Range(0, bossAttacks.Count);
            bossAttacks[attack].PlayAnimation();
            searchAttack = false;
        }

        if (searchAttack == false)
        {
            currentTime = currentTime - (1 * Time.deltaTime);

            if (currentTime <= 0)
            {
                searchAttack = true;
                currentTime = Cooldown;
            }
        }

    }

    public void Attack()
    {
        bossAttacks[attack].Attack();
    }

    public void StopAnimation()
    {
        anim.SetInteger("attack", -1);
    }
}
