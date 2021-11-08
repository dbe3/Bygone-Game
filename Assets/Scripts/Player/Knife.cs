using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public Rigidbody2D knifeRb;
    public float knifeSpeed = 5f;
    public float MovementSmoothing = 0.05f;
    private Vector3 m_Velocity = Vector3.zero;
    Vector3 targetVelocity;

    public PlayerController playerController;
    public Transform player;
    int direction;

    public void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerController.facingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        Vector3 theScale = transform.localScale;
        theScale.x *= direction;
        transform.localScale = theScale;

        targetVelocity = new Vector2(knifeSpeed * 10f * direction, knifeRb.velocity.y);
    }

    public void Update()
    {
        knifeRb.velocity = Vector3.SmoothDamp(knifeRb.velocity * Time.deltaTime, targetVelocity, ref m_Velocity, MovementSmoothing);
        if (Vector3.Distance(player.position, knifeRb.position) >= 12)
        {
            Destroy(gameObject);
        }   
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        

        if (collision.gameObject.tag == "Enemy")
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (!enemy.isDamaged)
            {
                enemy.isDamaged = true;
                Debug.Log(enemy.isDamaged);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }

}
