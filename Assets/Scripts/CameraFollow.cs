using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    public Vector3 offset;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); ;
    }

    public void FixedUpdate()
    {
        transform.position = Player.position + offset;
    }

}
