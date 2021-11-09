using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnPos : MonoBehaviour
{
    private GameMaster gm;
    public Vector2 TestingVector;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        if (gm.lastCheckpointPos == new Vector2(0, 0))
        {
            transform.position = TestingVector;
        }
        else
        {
            transform.position = gm.lastCheckpointPos;
        }
    }

}
