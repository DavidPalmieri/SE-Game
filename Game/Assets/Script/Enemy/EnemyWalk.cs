using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour {


    NavMeshAgent navMeshAgent;
    EnemySight enemySight;


	// Use this for initialization
	void Awake () {

        navMeshAgent = GetComponent<NavMeshAgent>();
        enemySight = GetComponent<EnemySight>();



	}
	
	// Update is called once per frame
	void Update () {
		
        //Leads enemy to player
        if(enemySight.playerInSight == true)
        {
            navMeshAgent.SetDestination(enemySight.target.transform.position);
        }
	}
}
