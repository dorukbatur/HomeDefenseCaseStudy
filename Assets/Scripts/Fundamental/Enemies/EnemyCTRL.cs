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
    }

    
    private void FixedUpdate()
    {
        DecideNextMove();
    }

    
    private void DecideNextMove()
    {
        
        //TODO POLİSH AT 
        switch (enemyMoveState)
        {
            case 0:// playera doğru yürü
                direction = Vector3.Normalize(targetPos.position - transform.position);
                transform.forward = direction;
                rb.velocity = direction * speed;
                break;
            case 1://bariyere saldır
                if (barrier.HealthPoints <= 0)
                {
                    enemyMoveState = 0;
                    break;
                }
                if (timer < 0)
                {
                    timer = 0.5f;
                    AnimateAttackToBarrier();
                    barrier.TakeDamage(damagePoints);//süreyle yap bu işi ya da anim event 
                }
                timer -= Time.fixedDeltaTime;
                break;
            case 2://playera saldır
                if (timer < 0)
                {
                    timer = 0.5f;
                    AnimateAttackToPlayer();
                    //todo attack player
                }
                timer -= Time.fixedDeltaTime;
                break;
            case 3:
                AnimateDeath();
                break;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        barrier = other.GetComponent<PlayerBarrier>();
        playerCTRL = other.GetComponent<PlayerCTRL>();
        if (barrier)
        {
            enemyMoveState = 1;
        }
        else if (playerCTRL)
        {
            enemyMoveState = 2;
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
            OnEnemyDeath();
        }
    }
    
    
    public void OnEnemyDeath()
    {
        enemyMoveState = 3;
        
        //enemy death() animate öldür, blood particle
        //todo çarı öldür enemy managera söyle progressbar doldursun
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