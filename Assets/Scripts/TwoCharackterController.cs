using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoCharackterController : MonoBehaviour
{

    public Animator anim;

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

    public float LadderSpeed;
    public float LadderSpeedPy;

    bool isJumping;

    float startX;

    void Start()
    {
        Climbing = false;
        startX = transform.localScale.x;
    }



    void Update()
    {

        MySpeedX = Input.GetAxis("Horizontal");



        if (rb.velocity.x > 0.1 || rb.velocity.x < -0.1)
        {
            anim.SetBool("isRunning", true);
        }
        else if(rb.velocity.x <= 0.1 && rb.velocity.x >= -0.1)
        {
            anim.SetBool("isRunning", false);
        }


        if (MySpeedX < 0)
        {
            transform.localScale = new Vector3(-startX, transform.localScale.y, transform.localScale.z);
        }
        else if(MySpeedX > 0)
        {
            transform.localScale = new Vector3(startX, transform.localScale.y, transform.localScale.z);
        }


        anim.SetFloat("LadderSpeed", MySpeedY * LadderSpeed);
        

        if (!Climbing)
        {
            anim.SetBool("isClimbing", false);
            rb.useGravity = true;
            RunAnJump();
        }
        else
        {
            anim.SetBool("isClimbing", true);
            ClimbUpdate();
        }

        if (IsGroundedCheck())
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
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
            anim.SetBool("isJumping", true);
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
        rb.velocity = new Vector2(rb.velocity.x, MySpeedY * Speed * LadderSpeedPy * Time.deltaTime);
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
