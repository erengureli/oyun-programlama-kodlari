using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    public float speed = 5;
    public float horizontal;
    public float vertical;
    
    void Start()
    {
        transform.Translate(new Vector3(0, 2, 0));
    }

    
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed);

        // transform.Translate(new Vector3( 0, speed, 0) * Time.deltaTime);
    }
}
