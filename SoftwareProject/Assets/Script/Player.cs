using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int fcount = 30;
    private float gLevel = (float)0.0;
    private bool grounded = true;

    private float jumpForce = Physics.gravity.magnitude/2;

    private float walkMovementSpeed = 10f;
    private float attackMovementSpeed = 1f;

    // Wont walk of screen
    private float xMin = -30f, xMax = 30f, zMin = -5f, zMax = 5f;
    private float movementSpeed;

    //the characters body
    private Rigidbody rigidBody;

    //bool condition
    public bool facingRight;

    // accesses animator
    private Animator anim;

    //Animator State Info
    AnimatorStateInfo currentStateInfo;

    public Collider attack1Box, attack2Box;
    public Sprite attack1SpriteHitFrame, attack2SpriteHitFrame;

    SpriteRenderer currentSprite;

    //States
    static int currentState;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int runState = Animator.StringToHash("Base Layer.Run");

    static int attack1State = Animator.StringToHash("Base Layer.Attack1");
    static int heavySlashState = Animator.StringToHash("Base Layer.HeavySlash");

    //jump
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    //block
    static int blockState = Animator.StringToHash("Base Layer.Block");
    //hurt
    static int hurtState = Animator.StringToHash("Base Layer.Hurt");
    //fall
    static int fallState = Animator.StringToHash("Base Layer.Fall");








    private void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody>();
        movementSpeed = walkMovementSpeed;
        facingRight = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(idleState);
        currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        currentState = currentStateInfo.fullPathHash;
        /*
        if (currentState == idleState)
        {
            Debug.Log("Idle State");
        }
        if (currentState == runState)
        {
            Debug.Log("Run State");
        }
        if (currentState == hurtState)
        {
            Debug.Log("Hurt State");
        }
        if (currentState == fallState)
        {
            Debug.Log("Fall State");
        }
        if (currentState == blockState)
        {
            Debug.Log("Block State");
        }


        */

        //-Control Speed Based on Commands --------------------------------------------------
        if (currentState == idleState || currentState == runState)
        {
            movementSpeed = walkMovementSpeed;
        }
        else
        {
            movementSpeed = attackMovementSpeed;
        }

    }

    private void FixedUpdate()
    {
        fcount++;

        // ----Movement -------------------------------------------------------------------------------------------

        grounded = rigidBody.transform.localPosition.y < gLevel;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * movementSpeed, rigidBody.velocity.y, moveVertical * movementSpeed);

        rigidBody.velocity = movement;

        rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, xMin, xMax), transform.position.y, Mathf.Clamp(rigidBody.position.z, zMin, zMax));



        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }

        anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x + rigidBody.velocity.z));


        // - Combo Attacks ----------------------------------------------

        //Attack1 and Attack2
        if (Input.GetKey(KeyCode.Space))
        {
            if (fcount > 48 || fcount < 6)
            {
                anim.SetBool("Attack", true);
                fcount = 0;
                anim.SetBool("Attack2", false);
            }
            else
            {
                anim.SetBool("Attack2", true);
                anim.SetBool("Attack", false);
            }
        }

        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Attack2", false);
        }


        if (attack1SpriteHitFrame == currentSprite.sprite)
        {
            Attack(attack1Box, 5);
        }

        if (attack2SpriteHitFrame == currentSprite.sprite)
        {
            Attack(attack2Box, 10);
        }

        // - Jump ------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.RightShift)&&grounded)
        {
            anim.SetBool("Jump", true);
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 10, rigidBody.velocity.z);
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            anim.SetBool("Jump", true);
            rigidBody.AddForce(Vector3.up * jumpForce);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }

    private void Attack(Collider aBox, int v)
    {
        Collider[] hit = Physics.OverlapBox(aBox.bounds.center, aBox.bounds.extents, aBox.transform.rotation, LayerMask.GetMask("eHit"));
        foreach (Collider h in hit)
        {
            h.SendMessageUpwards("Hit", v);
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
