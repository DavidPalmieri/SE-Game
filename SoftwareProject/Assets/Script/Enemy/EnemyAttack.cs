using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttack : MonoBehaviour
{


    public float attackRange;
    public float attackStartDelay;

    public GameObject spriteObject;

    public Collider attack1Box, attack2Box;
    public Sprite attack1SpriteHitFrame, attack2SpriteHitFrame;
    public Sprite currentSprite;
    NavMeshAgent navMeshAgent;
    EnemySight enemySight;
    EnemyWalk enemyWalk;
    Animator animator;
    public int fCount;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemySight = GetComponent<EnemySight>();
        enemyWalk = GetComponent<EnemyWalk>();
        animator = spriteObject.GetComponent<Animator>();

    }

    // Use this for initialization
    void Start()
    {
        fCount = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        currentSprite = spriteObject.GetComponent<SpriteRenderer>().sprite;

        if (enemySight.playerInSight == true && enemySight.targetDistance < attackRange && ++fCount > 60)
        {

            animator.SetBool("Attack", true);

            if (attack1SpriteHitFrame == currentSprite)
            {
                fCount = 0;
                Attack(attack1Box, 1);
            }
            else if (attack2SpriteHitFrame == currentSprite)
            {
                Attack(attack2Box, 2);
            }
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    private void Attack(Collider aBox, int damage)
    {
        Collider[] hit = Physics.OverlapBox(aBox.bounds.center, aBox.bounds.extents, aBox.transform.rotation, LayerMask.GetMask("pHit"));
        foreach (Collider col in hit)
        {
            col.SendMessageUpwards("Hit", damage);
        }
    }
}
