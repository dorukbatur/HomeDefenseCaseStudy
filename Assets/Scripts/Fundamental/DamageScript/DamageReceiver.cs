using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private IDamageable parent;
    [SerializeField] private bool isDestroyable = false;

    public void Init(IDamageable parent)
    {
        this.parent = parent;
    }

    public void OnTakeDamage(float damage)
    {
        parent.ReceiveDamage(damage, isDestroyable, this);
    }
}
