using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class VultureBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aiPath;
    [SerializeField] floatingHealthBar healthbar;
    [SerializeField] PlayerHealth playerhealth;
    [SerializeField] GameObject portal;
    public int maxhealth = 20;
    public int health;

    void Start()
    {
        health = maxhealth;
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new UnityEngine.Vector3(1f,1f,1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new UnityEngine.Vector3(-1f,1f,1f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            playerhealth.takeDamage(6);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthbar.UpdateHealthBar(health,maxhealth);
        if(health <= 0)
        {
            portal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
