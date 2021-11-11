using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject SpawnLoc;
    public bool bossSpawned;
    public GameObject TBC;
    bool bossDead;
    bool startCountdown;
    public float timer;

    public void Update()
    {
        if (bossSpawned == true)
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null)
            {
                startCountdown = true;
                bossDead = true;
                bossSpawned = false;
            }
        }

        if (startCountdown == true)
        {
            timer = timer - Time.deltaTime;

            if (timer <= 0)
            {
                TBC.SetActive(true);
            }
        }

        if (bossDead == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spawn Boss");
            GameObject bossClone = Instantiate(Boss, SpawnLoc.transform.position, transform.rotation);
            bossSpawned = true;
        }
    }
}
