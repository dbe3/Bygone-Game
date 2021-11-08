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

    [Header("GameObjects")]
    public GameObject Projectile;
    public List<GameObject> Locations = new List<GameObject>();

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
    }

    public void SpawnSkull()
    {
        bool spawn = false;

        if (spawn == false)
        {
            Vector2 shotLoc = new Vector2(transform.position.x + (1 * direction), transform.position.y);
            GameObject projectileClone = Instantiate(Projectile, shotLoc, transform.rotation);
            spawn = true;
        }

    }

    public void AttackDone()
    {
        anim.SetInteger("attack", -1);
        anim.SetBool("attackDone", true);
    }
}