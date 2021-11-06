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

    public void Update()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity * Time.deltaTime, targetVelocity, ref m_Velocity, MovementSmoothing);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Health--;
            
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
