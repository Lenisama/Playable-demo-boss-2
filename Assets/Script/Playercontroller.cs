using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Playercontroller : MonoBehaviour
{
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    public float walkSpeed = 5f;
    public bool _isFacingRight = true;
    private bool isFacingRight; 
    public float jumpImpulse = 10f;

    public bool GetIsFacingRight()
    { return _isFacingRight; }
    private void SetIsFacingRight(bool value)
    {
        if (value)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
        _isFacingRight = value;
    }
    Rigidbody2D rb;
    Animator animator;
    [SerializeField]
    private bool _isMoving = false;
   

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }

        private set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    public bool IsFacingRight { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        animator.SetFloat("yVelocity", rb.velocity.y);
        if(moveInput.x != 0)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        SetFacingDirection();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        }
    }
    private void FixUpdate()
    {

    }
    private void SetFacingDirection()
    {
        if(moveInput.x > 0 && !GetIsFacingRight())
        {
            SetIsFacingRight(true);
        }
        else if (moveInput.x < 0 && GetIsFacingRight())
        {
            SetIsFacingRight(false);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        //Check if alive
        if(context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
