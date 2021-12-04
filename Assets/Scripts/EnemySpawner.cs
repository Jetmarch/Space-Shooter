using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnRate;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float minY;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnRate);
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyList.Count);
        Debug.Log(randomEnemy);

        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minY, maxY);

        Instantiate(enemyList[randomEnemy], new Vector3(spawnX, spawnY), enemyList[randomEnemy].transform.rotation);
    }
}
