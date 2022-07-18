using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent fishGuy;

    public Transform player;

    public LayerMask isGround, isPlayer;

    [Header("Idle")]
    public Vector3 idlePoint;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int attackTest;

    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttack;


    public void Start()
    {
        idlePoint = transform.position;
    }
    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if(!playerInSight && !playerInAttack)
        {
            Idle();
        }

        if(playerInSight && !playerInAttack)
        {
            Chasing();
        }

        if (playerInAttack && playerInAttack)
        {
            Attacking();
        }
    }

    void Idle()
    {
        fishGuy.SetDestination(idlePoint);
    }

    void Chasing()
    {
        fishGuy.SetDestination(player.position);
    }

    void Attacking()
    {
        fishGuy.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Attack();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void Attack()
    {
        attackTest++;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
