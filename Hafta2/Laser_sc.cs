using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);

        if(transform.position.y >= 7){
            Destroy(this.gameObject);
        }
    }
}
