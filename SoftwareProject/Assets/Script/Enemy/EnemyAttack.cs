using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttack : MonoBehaviour {


    public float attackRange;
    public float attackStartDelay;

    public GameObject spriteObject;

    public GameObject attack1Box, attack2Box;
    public Sprite attack1SpriteHitFrame, attack2SpriteHitFrame;
    public Sprite currentSprite;
    NavMeshAgent navMeshAgent;
    EnemySight enemySight;
    EnemyWalk enemyWalk;
    Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemySight = GetComponent<EnemySight>();
        enemyWalk = GetComponent<EnemyWalk>();
        animator = spriteObject.GetComponent<Animator>();
            
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        currentSprite = spriteObject.GetComponent<SpriteRenderer>().sprite;

        if (enemySight.playerInSight == true && enemySight.targetDistance < attackRange)
        {

            animator.SetBool("Attack", true);

            if (attack1SpriteHitFrame == currentSprite)
            {
                attack1Box.gameObject.SetActive(true);
            }
            else if (attack2SpriteHitFrame == currentSprite)
            {
                attack2Box.gameObject.SetActive(true);
            }
            else
            {
                attack1Box.gameObject.SetActive(false);
                attack2Box.gameObject.SetActive(false);
            }
        }





    }
}
