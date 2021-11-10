using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public bool isPlayerDead;
    public bool isDamaged;
    public bool canBeDamaged;
    public float invulTime;
    float timer;
    
    public void Update()
    {
        if (Health <= 0)
        {
            isPlayerDead = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (canBeDamaged == false)
        {
            timer = timer - (1 * Time.deltaTime);

            if (timer <= 0 )
            {
                canBeDamaged = true;
                timer = invulTime;
            }
        }
    }

}
