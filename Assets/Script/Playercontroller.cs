using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection))]
public class Playercontroller : MonoBehaviour
{
	Vector2 moveInput;
	TouchingDirection touchingDirection;
	public Damageable damageable;
	public float walkSpeed = 5f;
	public float airWalkSpeed = 10f;
	public bool _isFacingRight = true;
	private bool isFacingRight;
	public float jumpImpulse = 10f;
	public float fallMultiplier = 2.5f;
	public float shortJumpMultiplier = 1.5f;
	public float attackCooldown = 0.1f;

	private float lastAttack;
	private bool isDashing;
	public bool canDash;
	private float dashTime;

	public bool GetIsFacingRight()
	{
		return _isFacingRight;
	}

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

	public bool CanMove
	{
		get { return animator.GetBool("canMove"); }
	}

	Rigidbody2D rb;
	Animator animator;
	[SerializeField] private bool _isMoving = false;


	public bool IsMoving
	{
		get { return _isMoving; }

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
		touchingDirection = GetComponent<TouchingDirection>();
	}

	// Start is called before the first frame update
	void Start() { }

	// Update is called once per frame
	void Update()
	{
		moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if (canDash && !isDashing && Input.GetKeyDown(KeyCode.LeftShift) && Mathf.Abs(moveInput.x) > 0)
		{
			isDashing = true;
			canDash = false;
		}

		if (isDashing && dashTime < 0.05f)
		{
			rb.velocity = Vector2.right * Mathf.Sign(moveInput.x) * walkSpeed * 7.5f;
			dashTime += Time.deltaTime;
			damageable.isInvincible = true;
			return;
		}
		else
		{
			isDashing = false;
			dashTime = 0f;
		}

		if (Input.GetButtonDown("Attack_1") && Time.time > lastAttack + attackCooldown)
		{
			animator.SetTrigger("attack");
			lastAttack = Time.time;
		}

		if (CanMove)
		{
			if (touchingDirection.IsGrounded)
			{
				rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
			}
			else
			{
				rb.velocity = new Vector2(moveInput.x * airWalkSpeed, rb.velocity.y);
			}

			animator.SetFloat("yVelocity", rb.velocity.y);
			if (moveInput.x != 0)
			{
				IsMoving = true;
			}
			else
			{
				IsMoving = false;
			}
		}

		SetFacingDirection();
		if (Input.GetButtonDown("Jump") && touchingDirection.IsGrounded && CanMove)
		{
			// rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);

			animator.SetTrigger("jump");
			canDash = true;
			rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
		}

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
		}
		else if (!Input.GetButton("Jump"))
		{
			rb.velocity += Vector2.up * (Physics2D.gravity.y * (shortJumpMultiplier - 1) * Time.deltaTime);
		}
	}


	private void SetFacingDirection()
	{
		if (moveInput.x > 0 && !GetIsFacingRight())
		{
			SetIsFacingRight(true);
		}
		else if (moveInput.x < 0 && GetIsFacingRight())
		{
			SetIsFacingRight(false);
		}
	}
}