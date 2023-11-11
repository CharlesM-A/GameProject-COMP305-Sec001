using UnityEngine;

public class playermovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 700f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Check if the player is grounded
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
    }
}