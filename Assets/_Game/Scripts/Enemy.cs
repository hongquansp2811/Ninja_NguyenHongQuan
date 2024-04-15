using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float range;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject attackArea;
    private IStage currentStage;
    private bool isRight = true;
    private Character taget;
    public Character Taget => taget;

    private void Update()
    {
        if (currentStage != null && !IsDeath)
        {
            currentStage.OnExecute(this);
        }
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }

    public override void OnInit()
    {
        base.OnInit();
        ChangStage(new IdleStage());
        DeActiveAttack();
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(gameObject);
    }

    public void ChangStage(IStage newStage)
    {
        if (currentStage != null)
        {
            currentStage.OnExit(this);
        }
        currentStage = newStage;
        if (currentStage != null)
        {
            currentStage.OnEnter(this);
        }
    }

    public void Moving()
    {
        ChangeAnim("run");
        rb.velocity = transform.right * moveSpeed;
    }

    public void StopMoving()
    {
        ChangeAnim("idle");
        rb.velocity = Vector2.zero;
    }

    public void Attack()
    {
        ChangeAnim("attack");
        ActiveAttack();
        Invoke(nameof(DeActiveAttack), 0.5f);
    }

    public bool IsTagetInRange()
    {
        if (Vector2.Distance(taget.transform.position, transform.position) <= range)
            return true;
        else  
            return false; 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyWall")
        {
            Debug.Log("BBBBBBBBBBBBBBBBBB");
            ChangeDirection(!isRight);
        }  
    }

    public void ChangeDirection(bool isRight)
    {
        this.isRight = isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }

    private void DeActiveAttack()
    {
        attackArea.SetActive(false);
    }

    internal void SetTaget(Character character)
    {
        this.taget = character;
        if (IsTagetInRange())
        {
            ChangStage(new AttackStage());
        }
        else if (Taget != null)
        {
            ChangStage(new PatrolStage());
        }
        else
        {
            ChangStage(new IdleStage());
        }
    }
}
