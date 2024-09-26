using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCTRL : MonoBehaviour,IDamageable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int healthPoints = 50;
    [SerializeField] private int damagePoints = 10;
    [SerializeField] private Animator enemyAnimatorCTRL;

    private static int AttackPlayer = Animator.StringToHash("AttackPlayer");
    private static int AttackBarrier = Animator.StringToHash("AttackBarrier");
    private static int Walk = Animator.StringToHash("Walk");
    private static int Die = Animator.StringToHash("Die");
    
    private DamageReceiver[] _receivers;
    private int enemyMoveState = 0;
    private float speed;
    private Transform targetPos;
    private Vector3 direction;
    private float timer = 1f;
    private PlayerBarrier barrier;
    private PlayerCTRL playerCTRL;
    
    public void Init(Transform targetPos, float speed)
    {
        this.targetPos = targetPos;
        this.speed = speed;
        _receivers = GetComponentsInChildren<DamageReceiver>();//todo bu değişebilir
        foreach (DamageReceiver receiver in _receivers)
            receiver.Init(this);
        AnimateMove();
    }

    
    private void FixedUpdate()
    {
        if (enemyMoveState == 0)
        {
            EnemyMove();
        }
    }

    private void EnemyMove()
    {
        direction = Vector3.Normalize(targetPos.position - transform.position);
        transform.forward = direction;
        rb.velocity = direction * speed;
    }

    public void EnemyAttackBarrier()
    {
        if (barrier.HealthPoints <= 0)
        {
            enemyMoveState = 0;
            return;
        }
        AnimateAttackToBarrier();
    }

    public void BarrierReceiveDamage()
    {
        barrier.TakeDamage(damagePoints);
        EnemyAttackBarrier();
    }
    
    public void EnemyAttackPlayer()
    {
        AnimateAttackToPlayer();
        //todo lose screen
    }

    public void EnemyDeath()
    {
        enemyMoveState = 3;
        AnimateDeath();
        foreach (DamageReceiver receiver in _receivers)
            receiver.CloseColliders();
        //todo manager duyacak
        Destroy(gameObject, 4f);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        PlayerBarrier barrier = other.GetComponent<PlayerBarrier>();
        PlayerCTRL playerCTRL = other.GetComponent<PlayerCTRL>();
        if (barrier)
        {
            if (enemyMoveState == 1)
                return;
            this.barrier = barrier;
            enemyMoveState = 1;
            EnemyAttackBarrier();
        }
        else if (playerCTRL)
        {
            if (enemyMoveState == 2)
                return;
            this.playerCTRL = playerCTRL;
            enemyMoveState = 2;
            EnemyAttackPlayer();
        }
    }
    
    public void ReceiveDamage(int damage, bool isDestroyable, bool isLastDestroyable, DamageReceiver receiverObject)
    {
        if (enemyMoveState == 3)
            return;
        healthPoints -= damage;
        if (isDestroyable && !isLastDestroyable)
        {
            receiverObject.HideDamagedPart();
        }
        if (healthPoints <= 0)
        {
            if (isLastDestroyable)
            {
                receiverObject.HideDamagedPart();
            }
            EnemyDeath();
        }
    }
    

    #region Animations

    public void AnimateMove()
    {
        enemyAnimatorCTRL.SetTrigger(Walk);
    }

    public void AnimateAttackToPlayer()
    {
        enemyAnimatorCTRL.SetTrigger(AttackPlayer);
    }
    public void AnimateAttackToBarrier()
    {
        enemyAnimatorCTRL.SetTrigger(AttackBarrier);
    }
    public void AnimateDeath()
    {
        enemyAnimatorCTRL.SetTrigger(Die);
    }

    #endregion
}