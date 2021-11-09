using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject SpawnLoc;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spawn Boss");
            GameObject bossClone = Instantiate(Boss, SpawnLoc.transform.position, transform.rotation);
        }
    }
}
