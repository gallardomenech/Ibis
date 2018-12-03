﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    public bool facingRight = true;

    public bool isGrounded;
    public Transform feetPose;
    public float checkRadius;
    public LayerMask whatIsGround;


    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public float plumaSpeed = 600.0f;
    public Transform plumaSpawn;
    public Rigidbody plumaPrefab;

    Rigidbody clone;

    // Use this for initialization

    void Awake()
    {
        plumaSpawn = GameObject.Find("PlumaSpawn").transform;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = false;
        Collider[] cols = Physics.OverlapSphere(feetPose.position, checkRadius, whatIsGround);
        if(cols.Length > 0) isGrounded = true;

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);
        if (moveInput > 0.0f && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0.0f && facingRight)
        {
            Flip();
        }



     

        if (Input.GetKeyDown("c"))
        {
            Attack();
        }
    }

    void Update()
    {



        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            //rb.velocity = Vector3.up * jumpForce;
            
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)){

            isJumping = false;

        }

    }



    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }





    void Attack()
    {
        clone = Instantiate(plumaPrefab, plumaSpawn.position, plumaSpawn.rotation) as Rigidbody;
        clone.AddForce(plumaSpawn.transform.right * plumaSpeed);
    }

}
