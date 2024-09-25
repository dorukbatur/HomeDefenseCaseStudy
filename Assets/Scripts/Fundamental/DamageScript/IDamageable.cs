using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void ReceiveDamage(int damage, bool isDestroyable, bool isLastDestroyable, DamageReceiver receiverObject);

}
