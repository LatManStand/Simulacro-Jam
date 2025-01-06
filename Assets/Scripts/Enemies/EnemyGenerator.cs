using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;

    public float defaultSpawnTime;
    public float variableSpawnTime;

    public List<Enemy> enemyPrefabs;
    public List<Enemy> enemies;

    public Transform bulletsParent;

    public float spawnDistance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
        enemies.Add(newEnemy);

        newEnemy.transform.position = (Vector2)PlayerController.instance.transform.position + Random.insideUnitCircle.normalized * spawnDistance;
        newEnemy.transform.parent = transform;

        Invoke(nameof(SpawnEnemy), defaultSpawnTime + Random.Range(-variableSpawnTime, variableSpawnTime));
    }

    public void KillEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
        if (enemies.Count == 0)
        {
            CancelInvoke(nameof(SpawnEnemy));
            SpawnEnemy();
        }
    }
}
