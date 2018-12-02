using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{

    public bool playerInSight;

    public GameObject player;
    public GameObject target;

    public float targetDistance;

    public bool playerOnRight;
    public Vector3 playerRelativePosition;

    //Advanced Targeting
    public GameObject frontTarget;
    public GameObject backTarget;

    public float frontTargetDistance;
    public float backTargetDistance;

    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        frontTarget = GameObject.Find("Enemy Front Target");
        backTarget = GameObject.Find("Enemy Back Target");

    }

    // Update is called once per frame
    void Update()
    {
        //target = player;

        playerRelativePosition = player.transform.position - gameObject.transform.position;
        if (playerRelativePosition.x < 0)
        {
            playerOnRight = false;
        }
        else if (playerRelativePosition.x > 0)
        {
            playerOnRight = true;
        }

        frontTargetDistance = Vector3.Distance(frontTarget.transform.position, gameObject.transform.position);
        backTargetDistance = Vector3.Distance(backTarget.transform.position, gameObject.transform.position);


        if (frontTargetDistance < backTargetDistance)
        {
            target = frontTarget;
        }
        else if (frontTargetDistance > backTargetDistance)
        {
            target = backTarget;
        }

        targetDistance = Vector3.Distance(target.transform.position, gameObject.transform.position);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject == player)
        {
            playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {
            playerInSight = false;
        }
    }
}
