using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject pathPrefab;

    [SerializeField]
    float timeBetweenSpawns = 0.5f;

    [SerializeField]
    float spawnRandomRactor = 0.3f;

    [SerializeField]
    int numberOfEnemies = 5;

    [SerializeField]
    float moveSpeed = 2f;

    public GameObject EnemyPrefab { get => enemyPrefab; }
    public float TimeBetweenSpawns { get => timeBetweenSpawns; }
    public float SpawnRandomRactor { get => spawnRandomRactor; }
    public int NumberOfEnemies { get => numberOfEnemies; }
    public float MoveSpeed { get => moveSpeed; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }
}
