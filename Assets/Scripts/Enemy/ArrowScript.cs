using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float direction = 1;
    public float MovementSmoothing = 0.05f;
    private Vector3 m_Velocity = Vector3.zero;
    public Vector3 targetVelocity;

    public float arrowSpeed = 5f;

    public Rigidbody2D rb;
    public DamagePlayer damagePlayer;
    KnockbackScript kb;

    public void Start()
    {
    }

    public void Update()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity * Time.deltaTime, targetVelocity, ref m_Velocity, MovementSmoothing);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject player = collision.gameObject;
            kb = player.GetComponent<KnockbackScript>();
            damagePlayer.ReducePlayerHealth(player);
            kb.Knockback(gameObject);

        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
