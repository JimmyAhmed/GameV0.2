using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed = 50;
    public float currentSpeed;
    public float stoppingDistance = 5;
    public bool die = false;

    private PlayerMovement player;
    private EnemyAttacking enemyAttacking;
    private Animator animator;
    private NavMeshAgent agent;
    public bool startMove = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyAttacking = GetComponent<EnemyAttacking>();

    }

    private void Start()
    {
        StartCoroutine(waitStarting());
           
    }

    IEnumerator waitStarting()
    {
        yield return new WaitForSeconds(3);
        startMove = true;
    }

    private void Update()
    {
        if (!startMove)
            return;

        if(player)
        Move();
    }

    public virtual void Move()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= stoppingDistance)
        {
            agent.SetDestination(player.transform.position);
            animator.SetFloat("Move", 10);
            agent.speed = currentSpeed;

            currentSpeed += 2*Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 10, 15);

            animator.SetBool("Attack", false);
            enemyAttacking.StopAttack();
        }
        else
        {
            agent.SetDestination(transform.position);
            currentSpeed = 0;
            animator.SetFloat("Move", 0);

            enemyAttacking.Attack();
        }
      
    }

    
}
