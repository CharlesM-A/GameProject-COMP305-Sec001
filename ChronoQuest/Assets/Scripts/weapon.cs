using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject bulletprefab;
    private float cooldown = 1f;
    private float nextFire;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {   
            nextFire = Time.time + cooldown;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
    }
}
