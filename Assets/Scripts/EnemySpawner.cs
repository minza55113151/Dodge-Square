using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner instance;

    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private EnemyInfo enemyInfo;

    private GameObject enemyPrefab;
    private GameObject[] enemys;
    public int enemyCount = 0;
    private float time = 0f;
    private float timeFromStart = 0f;

    private Vector2 spawnPosition;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        enemys = new GameObject[10000];
        enemyInfo.speed = enemyInfo.constSpeed;
    }

    void Update()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        time += Time.deltaTime;
        timeFromStart += Time.deltaTime;
        if (time >= spawnRate)
        {
            time %= spawnRate;
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length == 0) {
                spawnPosition = transform.position;
            }
            else
            {
                spawnPosition = enemys[Random.Range(0, enemys.Length)].transform.position;
            }
            float random = Random.Range(0f, 1f);
            if (random < 0.2f && timeFromStart > 30f)
            {
                enemyPrefab = enemyPrefabs[0];
            }
            else if (random > 0.8f)
            {
                enemyPrefab = enemyPrefabs[2];
            }
            else
            {
                enemyPrefab = enemyPrefabs[1];
            }
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyCount++;

        }
    }
}
