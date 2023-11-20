using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeHit : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private LayerMask ground;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] floatingHealthBar healthBar;
    [SerializeField] ObjectiveLevelTwo EnemyObjective;
    private Animator anim;
    private Collider2D coll;
    public int damage;
    public PlayerHealth playerHealth;
    public int maxHealth = 10;
    public int health;
    private bool facingLeft = true;
    
    
    private void Awake()
    {
        // healthBar = GetComponent<floatingHealthBar>();
    }
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        // rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        Debug.Log(healthBar);
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Update()
    {
        // Move();
        if(anim.GetBool("Jumping"))
        {
            if(rb.velocity.y < .1)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        if(coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping",true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }

        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping",true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerHealth.takeDamage(damage);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
