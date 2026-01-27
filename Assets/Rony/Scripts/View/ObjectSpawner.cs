using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] List<GameObject> PlayerSpawnPoints;
    [SerializeField] List<GameObject> EnemySpawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var playerSpawnPoint in PlayerSpawnPoints)
        {
            Instantiate(PlayerPrefab, playerSpawnPoint.transform.position, Quaternion.identity);
        }
        foreach (var enemySpawnPoint in EnemySpawnPoints)
        {
            Instantiate(EnemyPrefab, enemySpawnPoint.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
