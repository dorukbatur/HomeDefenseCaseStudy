using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private IDamageable parent;
    [SerializeField] private bool isDestroyable = false;
    [SerializeField] private bool isLastDestroyable = false;
    [SerializeField] private Transform receiverObject;
    [SerializeField] private Collider _collider;

    public void Init(IDamageable parent)
    {
        this.parent = parent;
        _collider = GetComponent<Collider>();
    }

    public void OnTakeDamage(int damage)
    {
        parent.ReceiveDamage(damage, isDestroyable, isLastDestroyable,this);
    }

    public void HideDamagedPart()
    {
        _collider.enabled = false;
        receiverObject.gameObject.SetActive(false);
    }
}
