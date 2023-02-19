using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float runSpeed = 5;
    public float jumpSpeed = 5;
    public bool canJump = true;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        //pour ajouter directment rigidbody
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fondation"))
        {
            canJump = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //calcul du deplacement
        float horizontalMovement = Input.GetAxis("Horizontal")* runSpeed ;
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(transform.up * jumpSpeed,ForceMode2D.Impulse);
            canJump = false;
        }
        MovePlayer(horizontalMovement);
        Flip(rb2d.velocity.x);
        float charachterVelocity = Mathf.Abs(rb2d.velocity.x);
        animator.SetFloat("Speed",charachterVelocity);
    }

    private void MovePlayer(float _horizontalMovement)
    {
        rb2d.velocity = new Vector2(_horizontalMovement,rb2d.velocity.y);
       
    }
    private void Flip(float _velocity)
    {
        spriteRenderer.flipX = _velocity switch
        {
            > 0.1f => false,
            < -0.1f => true,
            _ => spriteRenderer.flipX
        };
    }
}
