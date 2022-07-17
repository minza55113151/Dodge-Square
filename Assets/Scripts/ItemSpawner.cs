using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] itemPrefabs;

    private float time = 0f;
    private Vector2 spawnPosition;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        SpawnItem();
    }
    private void SpawnItem()
    {
        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            time %= spawnRate;
            spawnPosition = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f));
            GameObject item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], spawnPosition, Quaternion.identity);
        }
    }
}
