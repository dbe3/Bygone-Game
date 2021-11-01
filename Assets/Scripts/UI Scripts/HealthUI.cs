using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image HeartContainer;
    public PlayerHealth playerHealth;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void AddHealth()
    {
        for (int i = 0; i < playerHealth.Health; i++)
        {
          
        }
    }

    public void ReduceHealth()
    {

    }
}
