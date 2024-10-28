using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    [SerializeField]
    float speed = 15f;

    float horizontal;
    float vertical;

    // Throw Projectile
    [SerializeField]
    GameObject laser;
    float fireRate = 2f;
    float nextFire = 0f;

    SpawnManager_sc spawnManager_sc;

    void Start()
    {
        spawnManager_sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();

        if(spawnManager_sc == null)
        {
            Debug.Log("Spawn Manager oyun nesnesi bulunamadı.");
        }
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

        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if(transform.position.x > 9.2f)
        {
            transform.position = new Vector3(-9.2f, transform.position.y, 0);
        }
        else if(transform.position.x < -9.2f)
        {
            transform.position = new Vector3(9.2f, transform.position.y, 0);
        } 
    }

    void ThrowProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire) )
        {
            Instantiate(laser, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void GetDamage()
    {
        health--;
        if(health <= 0)
        {
            if(spawnManager_sc != null)
            {
                spawnManager_sc.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }
}
