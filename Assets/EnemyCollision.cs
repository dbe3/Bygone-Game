using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");

        if (collision.gameObject.tag == "Knife")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {


    }
}
