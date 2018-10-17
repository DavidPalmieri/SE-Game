using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour {


    //Start with Variables

    public float enemySpeed;
    public float enemyCurrentSpeed;

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

            if(enemySight.targetDistance < 1.0f)
            {
                animator.SetBool("Walk", false);
            }
        }



	}
}
