using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.Health = 0;
        }
    }
}
