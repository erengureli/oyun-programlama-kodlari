using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    float speed = 3;

    [SerializeField]
    int bonusId;

    [SerializeField]
    AudioClip audioClip;

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
        AudioSource.PlayClipAtPoint(audioClip, transform.position);

        if(other.tag == "Player")
        {
            switch(bonusId)
            {
                case 0:
                    other.GetComponent<Player_sc>().ActivateTripleShot();
                    break;
                case 1:
                    other.GetComponent<Player_sc>().ActivateSpeedBonus();
                    break;
                default:
                    Debug.Log("Hatalı ID");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
