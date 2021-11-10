using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSprite : MonoBehaviour
{
    PlayerHealth ph;
    bool transparent;
    float invulTime;
    float timer;
    SpriteRenderer sr;

    [SerializeField]
    private Color damagedColor = Color.white;

    [SerializeField]
    private Color normalColor = Color.white;

    public void Start()
    {
        ph = GetComponent<PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        invulTime = ph.invulTime;
        timer = 0;
    }

    public void Update()
    {
        if (ph.canBeDamaged == false)
        {
            timer = timer - Time.deltaTime;

            if (timer <= 0)
            {

                if (transparent == true)
                {
                    sr.color = normalColor;
                    transparent = false;
                }
                else if (transparent == false)
                {
                    sr.color = damagedColor;
                    transparent = true;
                }

                timer = invulTime / 6;
            }
        }
        else
        {
            sr.color = normalColor;
            transparent = false;
            timer = 0;
        }
    }
}
