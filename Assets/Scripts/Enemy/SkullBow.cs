using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBow : MonoBehaviour
{
    public GameObject Arrow;
    public Enemy enemyScript;
    Animator anim;

    public float attackCooldown;
    float currentCooldown;

    bool canAttack;
    bool shot;

    int direction;
    public void Awake()
    {
        enemyScript = GetComponent<Enemy>();
    }

    void Start()
    {
        anim = enemyScript.anim;
        canAttack = true;
    }

    void Update()
    {
        enemyScript.DistanceChecker();       

        if (enemyScript.inAttackRange && canAttack)
        {
            anim.SetBool("isAttacking", true);
            currentCooldown = attackCooldown;
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        if (!canAttack)
        {
            currentCooldown = currentCooldown - (1 * Time.deltaTime);

            if (currentCooldown <= 0)
            {
                canAttack = true;
                shot = false;
            }
        }

        //Flip
        if (transform.position.x - enemyScript.Player.transform.position.x > 0 && !enemyScript.left)
        {
            enemyScript.Flip();
        }
        else if (transform.position.x - enemyScript. Player.transform.position.x < 0 && enemyScript.left)
        {
            enemyScript.Flip();
        }
    }
    public void doneAttacking()
    {
        canAttack = false;
        
    }

    public void Shoot()
    {
        if (!shot)
        {
            if (transform.position.x - enemyScript.Player.transform.position.x > 0)
            {
                direction = -1;
            }
            else if (transform.position.x - enemyScript.Player.transform.position.x < 0)
            {
                direction = 1;
            }

            Vector2 shotLoc = new Vector2(transform.position.x + (1.3f * direction), transform.position.y);

            GameObject shotArrow = Instantiate(Arrow, shotLoc, transform.rotation);
            Rigidbody2D rb = shotArrow.GetComponent<Rigidbody2D>();
            ArrowScript shotArrowScript = shotArrow.GetComponent<ArrowScript>();

            Vector3 arrowScale = shotArrow.transform.localScale;
            arrowScale.x *= (direction * -1);
            shotArrow.transform.localScale = arrowScale;

            Vector2 targetVelocity = new Vector2(shotArrowScript.arrowSpeed * 10f * direction, rb.velocity.y);
            
            shotArrowScript.targetVelocity = targetVelocity;
            shot = true;
        }
    }
}
