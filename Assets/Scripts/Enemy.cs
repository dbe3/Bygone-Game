using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float AttackRange;
    public int Health;
    public Animator anim;

    public GameObject Player;

    public float MoveSpeed;
    public Rigidbody2D rb;

    public bool inAttackRange;
    public bool left;
    public bool isDamaged;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void DistanceChecker()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) <= AttackRange && Mathf.Abs(transform.position.y - Player.transform.position.y) <= 1f)
        {
            inAttackRange = true;
        }
        else
        {
            inAttackRange = false;
        }
    }

    public void Flip()
    {
        left = !left;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector2 range = new Vector2(transform.position.x + (float)AttackRange, transform.position.y);
        Gizmos.DrawLine(transform.position, range);
    }
}
