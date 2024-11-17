using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : DamageReceiver
{    
    private void Awake()
    {
        hp = 100;
    }

    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {

        }
    }
}
