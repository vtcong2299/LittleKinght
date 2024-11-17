using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    private DamageReceiver dameReceiver;
    protected float damage = 1f;

    private void Awake()
    {
        dameReceiver = GetComponent<DamageReceiver>();
    }
    public virtual void CollisionSendDame(Collision collision)
    {
        if (collision == null)
        {
            return;
        }
        dameReceiver.Receiver(damage);
    }
    public void OnCollisionEnter(Collision collision)
    {
        CollisionSendDame(collision);
    }
}
