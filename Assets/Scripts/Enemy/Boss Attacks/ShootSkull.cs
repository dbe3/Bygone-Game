using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSkull : BossAttack
{
    public GameObject Projectile;
    public GameObject ShootLoc;

    public override void PlayAnimation()
    {
        anim.SetInteger("attack", 0);
    }

    public override void Attack()
    {
        base.Attack();
        Vector2 shotLoc = new Vector2(transform.position.x + (1 * bossScript.direction), transform.position.y);

        GameObject projectileClone = Instantiate(Projectile, shotLoc, transform.rotation);
    }

}
