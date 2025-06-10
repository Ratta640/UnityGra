using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public float jumpForce = 100;
    public float runSpeed = 10;

    public bool isGrounded;
    public GroundChecker groundChecker;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }





    // Update is called once per frame
    void Update()
    {
        if (health.isDead) return;

        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput >= 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (moveInput != 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }

        //Debug.Log($"Input pressed:{moveInput}");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {

            //rb.AddForce(new Vector2(0, jumpForce));
            rb.AddForce(Vector2.up * jumpForce);


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     isGrounded = true;
    // }

    //  private void OnCollisionExit2D(Collision2D collision)
    // {
    //    isGrounded = false; 
    // }
}
