using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject HeartContainer;
    public PlayerHealth playerHealth;
    public RectTransform GridLayout;
    public List<GameObject> Hearts = new List<GameObject>();

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        for (int i = 1; i <= playerHealth.Health; i++)
        {
            GameObject heart = Instantiate(HeartContainer);
            heart.transform.parent = GridLayout;
            Hearts.Add(heart);
        }
    }

}
