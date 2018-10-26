using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

    public bool playerInSight;

    public GameObject player;
    public GameObject target;

    public float targetDistance;

    //public bool playerOnRight;
    //public Vector3 playerRelativePosition;


    //public GameObject frontTarget;
    //public GameObject backTarget;

    //public float frontTargetDistance;
    //public float backTargetDistance;

	// Use this for initialization
	void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");
        //frontTarget = GameObject.FindGameObjectWithTag("Enemy Front Target");
        //backTarget = GameObject.FindGameObjectWithTag("Enemy Back Target");

    }

    // Update is called once per frame
    void Update () {
        target = player;
        targetDistance = Vector3.Distance(target.transform.position, gameObject.transform.position);

       /* playerRelativePosition = player.transform.position - gameObject.transform.position;
        if(playerRelativePosition.x < 0)
        {
            playerOnRight = false;
        }
        else if(playerRelativePosition.x > 0)
        {
            playerOnRight = true;
        }
        */
	}








    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject == player)
        {
            playerInSight = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject == player)
        {
            playerInSight = false;
        }


    }


}
