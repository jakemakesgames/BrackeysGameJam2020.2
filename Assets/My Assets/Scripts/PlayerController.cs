using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("MOVEMENT")]
    public Rigidbody2D rb2D;
    private float moveInput;
    public float moveSpeed;

    [Header("JUMPING")]
    public float jumpForce;

    public bool isJumping;

    public bool isGrounded;
    public Transform groundPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Awake()
    {
        instance = this;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb2D.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveInput * moveSpeed, rb2D.velocity.y);
    }
}
