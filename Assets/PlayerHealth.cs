using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    public void Update()
    {
        if (Health <= 0)
        {
            levelManager.RespawnPlayer();
            Health = 3;
        }
    }

}
