using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour {


    //Start with Variables

    public float enemySpeed;
    public float enemyCurrentSpeed;
    public bool facingRight;
    public GameObject spriteObject;

    Animator animator;
    NavMeshAgent navMeshAgent;
    EnemySight enemySight;

	// Use this for initialization
	void Awake () {
        
        //GetComponenet accesses component within Unity
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemySight = GetComponent<EnemySight>();
        animator = spriteObject.GetComponent<Animator>();

        navMeshAgent.speed = enemySpeed;

	}
	
	// Update is called once per frame
	void Update () {
		

        if(enemySight.playerInSight == true)
        {
            navMeshAgent.SetDestination(enemySight.target.transform.position);
            navMeshAgent.updateRotation = false;
            animator.SetBool("Walk", true);

            if(enemySight.targetDistance < .1f)
            {
                animator.SetBool("Walk", false);
            }
        }

        if(enemySight.playerOnRight == true && !facingRight)
        {
            Flip();
        }
        else if(enemySight.playerOnRight == false && facingRight)
        {
            Flip();
        }


	}


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 thisScale = transform.localScale;

        thisScale.x *= -1;
        transform.localScale = thisScale;


    }



}
