using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    private int health = 3;
    public float speed = 10f;
    private float horizontal;
    private float vertical;

    // Throw Projectile
    public GameObject laser;
    public float fireRate = 1f;
    private float nextFire = 0f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        CalculateMovement();
        ThrowProjectile();
    }

    void CalculateMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed);

        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if(transform.position.x > 9.2f)
        {
            transform.position = new Vector3(-9.2f, transform.position.y, 0);
        }
        else if(transform.position.x < -9.2f)
        {
            transform.position = new Vector3(9.2f, transform.position.y, 0);
        } 
    }

    void ThrowProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire) )
        {
            Instantiate(laser, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void GetDamage()
    {
        health--;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
