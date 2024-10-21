using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }
    
    void Update()
    {
        CalculateMovement();
        TeleporatUp();
    }

    void CalculateMovement()
    {
        transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
    }

    void TeleporatUp()
    {
        if(transform.position.y < -7)
        {
            transform.position = new Vector3(Random.Range(-9.2f, 9.2f), 7, 10);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player_sc player_Sc =  other.GetComponent<Player_sc>();
            player_Sc.GetDamage();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
