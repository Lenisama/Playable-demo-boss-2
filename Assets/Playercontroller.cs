using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{
    Vector2 moveInput;
    public float walkSpeed = 5f;
    public bool _isFacingRight = true;
    private bool isFacingRight;

    public bool GetIsFacingRight()
    { return _isFacingRight; }
    private void SetIsFacingRight(bool value)
    {
        if (_isFacingRight != value)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
        _isFacingRight = value;
    }
    Rigidbody2D rb;
    Animator animator;
    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving { get
    {
        return _isMoving;
    } 
    
    private set
    {
        _isMoving = value;
        animator.SetBool("isMoving", value);
    }}

    public bool IsFacingRight { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    }
    private void FixUpdate()
    {

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        //moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }
    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !GetIsFacingRight())
        {
            SetIsFacingRight(true);
        }
        else if (moveInput.x > 0 && GetIsFacingRight())
        {
            SetIsFacingRight(false);
        }
    }
}
