using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpingPower = 16f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool Grounded = false;
    Vector2 moveInput;

    public bool IsMoving { get; private set; }
    private string mainUI = "StartMenu";


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update() {
    } 

    public void Jump(InputAction.CallbackContext context) 
    {
       
        if (Grounded)
        {
            print("jumped1");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            GetComponent<AudioSource>().Play();
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            print("jumped2");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        IsGrounded();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        print(moveInput);
    }

    private void IsGrounded()
    {
        Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.4f, groundLayer);
        if(colliders.Length > 0)
        {
            // print("true");
            Grounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathObj"))
        {
            SceneManager.LoadScene(mainUI);
        }
    }

}
