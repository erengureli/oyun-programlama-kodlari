using UnityEngine;

public class Asteroid_sc : MonoBehaviour
{
    float rotateSpeed = 20f;
    
    [SerializeField]
    GameObject explosionPrefab;
    SpawnManager_sc spawnManager_Sc;

    void Start()
    {
        spawnManager_Sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        if(spawnManager_Sc == null) Debug.LogError("Asteroid_sc::Start spawnManager_Sc is NULL");
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            spawnManager_Sc.StartSpawning();
            Destroy(this.gameObject);
        }
    }
}
