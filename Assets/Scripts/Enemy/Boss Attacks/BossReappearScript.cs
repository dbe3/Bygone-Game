using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReappearScript : StateMachineBehaviour
{
    public List<GameObject> Locations;
    public BossScript bossScript;
    public GameObject Boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.gameObject;
        bossScript = Boss.GetComponent<BossScript>();
        Locations = bossScript.Locations;

        int index = Random.Range(0, Locations.Count);

        Vector2 spawnLoc = new Vector2(Locations[index].transform.position.x, Locations[index].transform.position.y);
        Boss.transform.position = spawnLoc;

        animator.SetBool("attackDone", false);
    }


}
