using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    protected float hp = 1f;

    public virtual bool IsDead()
    {
        return hp <= 0f;
    }

    public virtual void Receiver(float damage)
    {
        hp -= damage;
    }
}
