using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullyFadedScript : MonoBehaviour
{
    Animator anim;
    public GameObject GameOverUI;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FullyFaded()
    {
        anim.SetBool("faded", true);

        if (GameOverUI != null)
        {
            GameOverUI.SetActive(true);
        }
    }
}
