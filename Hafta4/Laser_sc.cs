using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);

        if(transform.position.y >= 7)
        {
            Destroy(this.gameObject);
        }
    }
}
