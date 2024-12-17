using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;
    
    Player_sc player_sc;

    Animator anim;

    void Start()
    {
        player_sc = GameObject.Find("Player").GetComponent<Player_sc>();
        if(player_sc == null) Debug.LogError("Enemy_sc::Start player_sc is NULL");
        
        anim = GetComponent<Animator>();
        if(anim == null) Debug.LogError("Enemy_sc::Start anim is NULL");
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
            transform.position = new Vector3(Random.Range(-9.2f, 9.2f), 7, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(player_sc != null)
                player_sc.GetDamage();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(player_sc != null)
                player_sc.UpdateScore(10);
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(this.gameObject, 1.0f);
        }
    }
}
