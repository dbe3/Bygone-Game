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
    public GameObject SkelBow;
    public List<GameObject> Locations = new List<GameObject>();
    public GameObject Center;
    public GameObject SkullSpawn1;
    public GameObject SkullSpawn2;
    public bool lowHp;
    public bool spawnCenter;
    public bool hasSpawnedCenter;
    public bool skullSummoned;
    int MaxHealth;
    public bool isDead;
    public GameObject TBC;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentTime = Cooldown;
        direction = -1;
        lowHp = false;
        MaxHealth = enemyScript.Health;
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

        if (enemyScript.Health <= MaxHealth / 2)
        {
            lowHp = true;
            spawnCenter = true;
        }

        if (enemyScript.Health <= 0)
        {
            isDead = true;
            Debug.Log("Boss Dead");
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

    public void SummonSkull()
    {
        Vector2 Spawn1 = new Vector2(SkullSpawn1.transform.position.x, SkullSpawn1.transform.position.y); 
        Vector2 Spawn2 = new Vector2(SkullSpawn2.transform.position.x, SkullSpawn2.transform.position.y);

        GameObject skullClone1 = Instantiate(SkelBow, Spawn1, transform.rotation);
        GameObject skullClone2 = Instantiate(SkelBow, Spawn2, transform.rotation);
    }
}