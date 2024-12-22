using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;
    
    Player_sc player_sc;

    Animator anim;

    AudioSource audioSource;

    void Start()
    {
        player_sc = GameObject.Find("Player").GetComponent<Player_sc>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        if(player_sc == null) Debug.LogError("Enemy_sc::Start player_sc is NULL");
        if(anim == null) Debug.LogError("Enemy_sc::Start anim is NULL");
        if(audioSource == null) Debug.LogError("Enemy_sc::Start audioSource is NULL");
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
            audioSource.Play();
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(this.gameObject, 2.5f);
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(player_sc != null)
                player_sc.UpdateScore(10);
            audioSource.Play();
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(this.gameObject, 2.5f);
        }
    }
}