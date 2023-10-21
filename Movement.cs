using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector3 movement = Vector3.zero;
    Animator animator;
    [SerializeField] float moveForce = 4;
    [SerializeField] float jumpForce = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement.Normalize();
        UpdateState();

    }
    private void FixedUpdate()
    {
        rb.AddForce(movement * moveForce);
    }
    void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        rb.velocity = Vector3.up * jumpForce;
    }

    void UpdateState()
    {

    }

}