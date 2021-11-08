using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullProjectileScript : MonoBehaviour
{
    GameObject Player;
    GameObject Boss;
    Vector3 targetLoc;
    bool targetSet;
    float standby = 1;
    public BossScript bossScript;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Boss = GameObject.FindGameObjectWithTag("Boss");
        bossScript = Boss.GetComponent<BossScript>();

        Vector3 theScale = transform.localScale;

        if (bossScript.direction == 1)
        {
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else if (bossScript.direction == -1)
        {
            theScale.x *= 1;
            transform.localScale = theScale;
        }
    }

    // Update is called once per frame
    void Update()
    {


        standby = standby - (1 * Time.deltaTime);

        if (standby <= 0)
        {
            if (targetSet == false)
            {
                targetLoc = Player.transform.position;
                targetSet = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetLoc, 20f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!(col.gameObject.tag == "Boss"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
