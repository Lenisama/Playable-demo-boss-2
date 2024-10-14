using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class Damageable : MonoBehaviour
{
	Animator animator;

	// Start is called before the first frame update
	public int _maxHealth = 100;

	public int MaxHealth
	{
		get { return _maxHealth; }
		set { _maxHealth = value; }
	}

	public int _health = 30;

	public int Health
	{
		get { return _health; }
		set
		{
			_health = value;
			if (_health < 0)
			{
				IsAlive = false;
			}
		}
	}

	public Image healthBarFill;

	private bool _isAlive = true;
	public bool isInvincible;
	private float timeSinceHit = 1;
	public float invinciblilityTime = 0.25f;

	public bool IsAlive
	{
		get { return _isAlive; }
		set
		{
			_isAlive = value;
			animator.SetBool("isAlive", value);
			Debug.Log("IsAlive set" + value);
		}
	}

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Hit(int damage)
	{
		if (IsAlive && !isInvincible)
		{
			Health -= damage;
			isInvincible = true;
			if (healthBarFill)
			{
				healthBarFill.fillAmount = (float) _health / _maxHealth;
			}
		}
	}

	private void Update()
	{
		if (isInvincible)
		{
			if (timeSinceHit > invinciblilityTime)
			{
				isInvincible = false;
				timeSinceHit = 0;
			}

			timeSinceHit += Time.deltaTime;
		}
	}

	void Start() { }
}