using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoCharackterController : MonoBehaviour
{
    [HideInInspector]
    public float MySpeedX;

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
        
    }



    void Update()
    {

        MySpeedX = Input.GetAxis("Horizontal");

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

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(MySpeedX * Speed * Time.deltaTime, rb.velocity.y);


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
