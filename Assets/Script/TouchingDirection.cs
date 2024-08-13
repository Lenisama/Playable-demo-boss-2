using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    [SerializeField]
    private bool _isGrounded;
    CapsuleCollider2D touchingCol;
    Rigidbody2D rb;
    Animator animator;

    public bool IsGrounded { get {
        return _isGrounded;
        } private set{
            _isGrounded = value;
            animator.SetBool("isGrounded", value);
        } }

    // Start is called before the first frame update
    private void Awake ()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
