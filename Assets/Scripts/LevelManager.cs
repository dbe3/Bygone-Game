using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Vector2 currentCheckpointPos;
    public GameObject player;
    public GameObject firstSpawn;
    public GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>(); 
        Instantiate(player, gm.lastCp, transform.rotation);
        

    }

    public void RespawnPlayer(Vector2 spawnPos)
    {
        //player.transform.position = currentCheckpointPos;
    }
}
