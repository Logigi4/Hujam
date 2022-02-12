using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoCharackterController : MonoBehaviour
{

    public bool Climbing = false;

    [HideInInspector]
    public float MySpeedX;
    [HideInInspector]
    public float MySpeedY;

    public float Speed;
    public float JumpSpeed;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;

    public Rigidbody rb;

    public CapsuleCollider capsuleCollider;

    public LayerMask groundLayerMask;

    private float JumpTimeCounter;
    public float JumpTime;

    bool isJumping;

    void Start()
    {
        Climbing = false;
    }



    void Update()
    {

        MySpeedX = Input.GetAxis("Horizontal");

        if (!Climbing)
        {
            rb.useGravity = true;
            RunAnJump();
        }
        else
        {
            ClimbUpdate();
        }


    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(MySpeedX * Speed * Time.deltaTime, rb.velocity.y);

        if (Climbing)
        {
            ClimbFixedUpdate();
        }


    }

    public void RunAnJump()
    {

        if (IsGroundedCheck() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump Tuþuna basýldý");
            isJumping = true;
            JumpTimeCounter = JumpTime;
            Jump();
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (JumpTimeCounter > 0)
            {
                Jump();
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    public void ClimbUpdate()
    {
        MySpeedY = Input.GetAxis("Horizontal");
        rb.useGravity = false;
    }
    public void ClimbFixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, MySpeedY * Speed * 0.75f * Time.deltaTime);
    }


    public void Jump()
    {

        rb.velocity = Vector2.up * JumpSpeed;
   
    }

    private bool IsGroundedCheck()
    {
        bool isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundLayerMask);

        return isGrounded;

    }

}
