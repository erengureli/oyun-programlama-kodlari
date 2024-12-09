using System.Collections;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    int health = 3;
    float speed = 15f;
    float speedMultiplier = 2f;

    float horizontal;
    float vertical;

    // Fire Laser
    [SerializeField]
    GameObject laser;

    [SerializeField]
    GameObject tripleShotPrefab;

    bool isTripleShotActive = false;
    //bool isSpeedBonusActive = false;

    float fireRate = 1f;
    float nextFire = 0f;

    int score = 0;

    SpawnManager_sc spawnManager_sc;
    UIManager_sc uiManager_Sc;

    void Start()
    {
        spawnManager_sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        uiManager_Sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();

        if(spawnManager_sc == null)
        {
            Debug.Log("Spawn Manager oyun nesnesi bulunamadı.");
        }
    }

    void Update()
    {
        CalculateMovement();
        FireLaser();
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

    void FireLaser()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire) )
        {
            if(!isTripleShotActive)
                Instantiate(laser, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            else
                Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);

            nextFire = Time.time + fireRate;
        }
    }

    public void GetDamage()
    {
        health--;
        uiManager_Sc.UpdateLivesIMG(health);
        if(health <= 0)
        {
            if(spawnManager_sc != null)
            {
                spawnManager_sc.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }
    
    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotBonusDisableRoutine());
    }

    public void ActivateSpeedBonus()
    {
        // isSpeedBonusActive = true;
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    IEnumerator SpeedBonusDisableRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speed /= speedMultiplier;
        // isSpeedBonusActive = false;
    }

    public void UpdateScore(int points)
    {
        score += points;
        if(uiManager_Sc != null)
            uiManager_Sc.UpdateScoreTMP(score);
    }
}
