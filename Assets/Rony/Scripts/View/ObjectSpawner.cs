using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] List<GameObject> PlayerSpawnPoints;
    [SerializeField] List<GameObject> EnemySpawnPoints;
    [SerializeField] BattleManager battleManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var playerSpawnPoint in PlayerSpawnPoints)
        {
            Debug.Log("Player Spawned");
            GameObject player = Instantiate(PlayerPrefab, playerSpawnPoint.transform.position, PlayerPrefab.transform.rotation);
            Player playerSpawned = player.GetComponent<Player>();
            battleManager.AddPlayer(playerSpawned);
        }
        foreach (var enemySpawnPoint in EnemySpawnPoints)
        {
            GameObject enemy = Instantiate(EnemyPrefab, enemySpawnPoint.transform.position, EnemyPrefab.transform.rotation);
            Enemy spawnedEnemy = enemy.GetComponent<Enemy>();
            battleManager.AddEnemy(spawnedEnemy);
        }

        battleManager.ChangeState(BattleState.Idle);
    }
}
