using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private bool isFacingRight = true;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Animator animator;
    
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        
        animator  = GetComponent<Animator>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction =  InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = moveAction.ReadValue<Vector2>().x;

        if (jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            animator.SetTrigger("TakeOff");
            rb.linearVelocity =  new Vector2(rb.linearVelocity.x, jumpingPower);
        }
        
        if (jumpAction.WasReleasedThisFrame() && rb.linearVelocity.y > 0f)
        {
            animator.ResetTrigger("TakeOff");
            rb.linearVelocity =  new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.2f);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        animator.SetBool("IsRunning", Math.Abs(rb.linearVelocity.x) > 0);
        animator.SetBool("IsJumping", !IsGrounded());
        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
