using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    [SerializeField] floatingHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health,maxHealth);
    }

    // Update is called once per frame
    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health,maxHealth);
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
