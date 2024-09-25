using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void ReceiveDamage(float damage, bool isDestroyable, DamageReceiver receiverObject);

}
