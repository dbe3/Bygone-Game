using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenScript : MonoBehaviour
{
    public GameObject BlackScreen;
    PlayerHealth playerHealth;
    Animator anim;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = BlackScreen.GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHealth.isPlayerDead == true)
        {
            BlackScreen.SetActive(true);
            anim.SetBool("gameOver", true);
        }
    }
}
