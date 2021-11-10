using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{

    public HealthUI healthUI;
    public PlayerHealth ph;
    public KnockbackScript kb;

    public void Start()
    {
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthUI = GameObject.FindGameObjectWithTag("UI").GetComponent<HealthUI>();
        kb = GameObject.FindGameObjectWithTag("Player").GetComponent<KnockbackScript>();
    }

    public void ReducePlayerHealth(GameObject player)
    {
        if (ph.canBeDamaged == true)
        {
            ph = player.GetComponent<PlayerHealth>();
            kb.Knockback(gameObject);
            ph.Health--;
            ReduceHealthUI();
            ph.canBeDamaged = false;
        }
    }

    public void ReduceHealthUI()
    {
            Destroy(healthUI.Hearts[healthUI.Hearts.Count - 1]);
            healthUI.Hearts.Remove(healthUI.Hearts[healthUI.Hearts.Count - 1]);           
    }
}
