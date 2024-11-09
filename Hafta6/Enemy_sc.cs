using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;
    
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
            transform.position = new Vector3(Random.Range(-9.2f, 9.2f), 7, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
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
