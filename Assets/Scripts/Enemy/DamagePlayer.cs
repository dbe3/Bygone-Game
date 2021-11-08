using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{

    public HealthUI healthUI;
    public PlayerHealth ph;

    public void Start()
    {
        healthUI = GameObject.FindGameObjectWithTag("UI").GetComponent<HealthUI>(); 
    }

    public void ReducePlayerHealth(GameObject player)
    {
        ph = player.GetComponent<PlayerHealth>();
        ph.Health--;
        ReduceHealthUI();
    }

    public void ReduceHealthUI()
    {       
        Destroy(healthUI.Hearts[healthUI.Hearts.Count - 1]);
        healthUI.Hearts.Remove(healthUI.Hearts[healthUI.Hearts.Count - 1]);
    }
}
