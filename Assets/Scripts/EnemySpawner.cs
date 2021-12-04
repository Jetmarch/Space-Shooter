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

    [SerializeField] private float minTorque;
    [SerializeField] private float maxTorque;


    public void StartEnemySpawn()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnRate);
    }

    public void StopEnemySpawn()
    {
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyList.Count);
        Debug.Log(randomEnemy);

        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minY, maxY);

        var enemy = Instantiate(enemyList[randomEnemy], new Vector3(spawnX, spawnY), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        enemy.GetComponent<Rigidbody2D>().AddTorque(Random.Range(minTorque, maxTorque));
    }
}
