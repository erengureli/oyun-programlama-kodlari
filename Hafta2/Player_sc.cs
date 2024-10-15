using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    public GameObject laser;
    public float speed = 8f;
    public float fireRate = 3f;
    public float nextFire = 0f;

    private float horizontal;
    private float vertical;
    
    void Start()
    {
        transform.Translate(new Vector3(0, 2, 0));
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

        if(transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y < -4){
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if(transform.position.x > 9.2f){
            transform.position = new Vector3(-9.2f, transform.position.y, 0);
        }
        else if(transform.position.x < -9.2f){
            transform.position = new Vector3(9.2f, transform.position.y, 0);
        } 
    }

    void ThrowProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire) ){
            Instantiate(laser, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
