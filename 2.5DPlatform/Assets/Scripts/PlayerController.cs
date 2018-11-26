using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public bool isGrounded;
    public Transform feetPose;
    public float checkRadius;
    public LayerMask whatIsGround;


    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    // Use this for initialization
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
    }

    void Update()
    {




        /*if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }*/




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

}
