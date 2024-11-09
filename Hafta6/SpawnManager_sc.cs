using System.Collections;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject tripleShotBonusPrefab;

    [SerializeField]
    GameObject enemyContainer;

    bool stopSpawning = false;

    IEnumerator SpawnRoutine()
    {
        while(!stopSpawning)
        {
            Vector3 position = new Vector3(Random.Range(-9.2f, 9.2f), 9, 0);
            GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator SpawnBonusRoutine()
    {
        while(!stopSpawning)
        {
            Vector3 position = new Vector3(Random.Range(-9.2f, 9.2f), 9, 0);
            Instantiate(tripleShotBonusPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }
}
