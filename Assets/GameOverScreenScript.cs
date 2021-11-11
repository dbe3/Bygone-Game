using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenScript : MonoBehaviour
{
    public GameObject BlackScreen;
    PlayerHealth playerHealth;
    Animator anim;
    public int Counter;
    float Timer;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = BlackScreen.GetComponent<Animator>();
        Timer = Counter;
    }

    void Update()
    {
        if (playerHealth.isPlayerDead == true)
        {
            Timer = Timer - Time.deltaTime;

            if (Timer <= 0)
            {
                Time.timeScale = 0;
            }



            BlackScreen.SetActive(true);
            anim.SetBool("gameOver", true);
        }
    }
}
