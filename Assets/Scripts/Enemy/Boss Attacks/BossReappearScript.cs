using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReappearScript : StateMachineBehaviour
{
    public List<GameObject> Locations;
    public BossScript bossScript;
    public GameObject Boss;
    public Enemy enemyScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.gameObject;
        bossScript = Boss.GetComponent<BossScript>();
        Locations = bossScript.Locations;
        int index = Random.Range(0, Locations.Count);
        GameObject Center = bossScript.Center;

        if (bossScript.spawnCenter == false || bossScript.hasSpawnedCenter == true)
        {
            Vector2 spawnLoc = new Vector2(Locations[index].transform.position.x, Locations[index].transform.position.y);
            Boss.transform.position = spawnLoc;
        }
        else if(bossScript.spawnCenter == true && bossScript.hasSpawnedCenter == false)
        {
            Vector2 spawnLoc = new Vector2(Center.transform.position.x, Center.transform.position.y);
            Boss.transform.position = spawnLoc;
            bossScript.hasSpawnedCenter = true;
        }


        animator.SetBool("attackDone", false);
    }


}
