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

    void Start()
    {
         
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
    }
}
