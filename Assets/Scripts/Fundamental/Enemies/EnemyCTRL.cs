using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private static int RandomInt = Animator.StringToHash("RandomInt");
    
    private DamageReceiver[] _receivers;
    private int enemyMoveState = 0;
    private float speed;
    private Transform targetPos;
    private Vector3 direction;
    private PlayerBarrier barrier;
    private PlayerCTRL playerCTRL;
    private EnemyManager manager;
    
    public void Init(EnemyManager manager,Transform targetPos, float speed)
    {
        this.targetPos = targetPos;
        this.speed = speed;
        this.manager = manager;
        _receivers = GetComponentsInChildren<DamageReceiver>();//todo bu değişebilir
        foreach (DamageReceiver receiver in _receivers)
            receiver.Init(this);
        StartCoroutine(RandomWait());
    }

    IEnumerator RandomWait()
    {
        var wait = new WaitForSeconds(Random.Range(0, 2f));
        AnimateMove();
        yield return wait;
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
        GameManager.instance.LevelEndWithScreen(false);
    }

    public void EnemyDeath()
    {
        enemyMoveState = 3;
        AnimateDeath();
        foreach (DamageReceiver receiver in _receivers)
            receiver.CloseColliders();
        manager.OnEnemyDeath(this);
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
        enemyAnimatorCTRL.SetInteger(RandomInt, Random.Range(0, 3));
        enemyAnimatorCTRL.SetTrigger(Die);
    }

    #endregion
}