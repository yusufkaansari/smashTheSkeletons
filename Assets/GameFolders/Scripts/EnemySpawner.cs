using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawnerPoints;

    [SerializeField]
    List<EnemyController> enemyPrefabs;

    [Range(1, 5)]
    [SerializeField]
    int atSameTimeSpawnMax = 5;

    [Range(0f, 0.5f)]
    [SerializeField]
    float minSpawnTime = 0f;

    [Range(0.5f, 2f)]
    [SerializeField]
    float maxSpawnTime = 2f;

    float floatTime;

    [Range(2,5)]
    [SerializeField]
    int timerSpawn = 1;

    float spawnTime;
    int enemyType,spawnPoint, atSameTimeSpawn;

    [SerializeField]
    Transform ballTransform;

    Vector3 shiftSpawner,sumshiftSpawner;

    // Start is called before the first frame update
    void Start()
    {
        ShiftSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    IEnumerator Spawner()
    {
        atSameTimeSpawn = Random.Range(0, atSameTimeSpawnMax+1);
        sumshiftSpawner.z = ballTransform.position.z - shiftSpawner.z;
        Debug.Log(atSameTimeSpawn);
        for (int i = 0; i < atSameTimeSpawn; i++)
        {
            enemyType = Random.Range(0, enemyPrefabs.Count);
            spawnPoint = Random.Range(0, spawnerPoints.Count);
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            Instantiate(enemyPrefabs[enemyType], spawnerPoints[spawnPoint].position + sumshiftSpawner , enemyPrefabs[enemyType].gameObject.transform.rotation, transform);
            yield return new WaitForSeconds(spawnTime);
        }
        
        
    }
    void Timer()
    {
        floatTime += Time.deltaTime;
        if (floatTime > timerSpawn)
        {
            StartCoroutine(Spawner());
            floatTime = 0;
        }
    }
    void ShiftSpawner()
    {
        shiftSpawner = Vector3.zero;
        shiftSpawner.z = ballTransform.position.z;
        sumshiftSpawner = Vector3.zero;
    }
}
