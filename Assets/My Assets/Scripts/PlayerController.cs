using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // create a static reference to itself

    

    [Header("MOVEMENT")]
    public Rigidbody2D rb2D; // private Rigidbody 2D component
    private float moveInput; // a float to store the player input
    public float moveSpeed; // a float to determine the player move speed

    [Header("JUMPING")]
    public float jumpForce; // how high will the player be able to jump

    public bool isJumping; // a bool to determine whether or not the player is jumping

    public bool isGrounded; // a bool to check whether or not the player is grounded
    public Transform groundPos; // the player's foot/ ground position
    public float checkRadius; // check radius
    public LayerMask whatIsGround; // ground layer

    void Awake()
    {
        instance = this;
        rb2D = GetComponent<Rigidbody2D>(); // set the rb2d variable to the rigidbody component on the player
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // set the move input to the Horizontal Axis input

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround); // check whether or not the player is grounded

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // if the player is grounded and if the spacebar is pressed
        {
            // the player is jumping, set the rb velocity
            isJumping = true;
            rb2D.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveInput * moveSpeed, rb2D.velocity.y); // move the player left and right based on horizontal inputs
    }
}
