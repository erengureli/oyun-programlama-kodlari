using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
        if(transform.position.y <= -7)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player_sc>().ActivateTripleShot();
            Destroy(this.gameObject);
        }
    }
}
