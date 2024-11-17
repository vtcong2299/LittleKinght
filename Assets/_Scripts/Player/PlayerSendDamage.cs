using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSendDamage : DamageSender
{
    private void Awake()
    {
        damage = 10;
    }

    public override void CollisionSendDame(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            base.CollisionSendDame(collision);
        }
    }

}
