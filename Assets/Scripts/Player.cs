using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 11.5f;
    public Transform groundCheck;              
    public float groundCheckRadius = 0.2f;    
    public LayerMask groundLayer;  

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool IsGrounded;
    private Animator animator; 

    float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            sr.flipX = false;
        }   
        else if (moveInput < 0)
        {
            sr.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        SetAnimation(moveInput);
           
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void SetAnimation(float moveInput)
    {
        if (IsGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Run");
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                animator.Play("Player_Jump");
            }
            else
            {
                animator.Play("Player_fall");
            }
        }
    }
}
