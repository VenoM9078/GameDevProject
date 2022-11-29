using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 7.5f;
    public Rigidbody2D rb;
    public float jumpForce;

    public bool isGrounded = false;
    public bool canDoubleJump = false;

    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private Animator animator;
    private SpriteRenderer sr;

    void Start()
    {
         animator = GetComponent<Animator>();
         sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 1f, whatIsGround);

        if(isGrounded == true)
        {
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded) { 
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            } else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }

        if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        } else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("isGrounded", isGrounded);


    }
}
