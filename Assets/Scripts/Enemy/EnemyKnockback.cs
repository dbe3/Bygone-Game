using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float knockbackPower = 125;
    public float knockbackDuration = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerKnockback.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }

}
