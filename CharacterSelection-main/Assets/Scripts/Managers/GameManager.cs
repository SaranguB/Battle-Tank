using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public void SpawnEnemy()
    {
        enemySpawner.SpawnEnemy();

        StartCoroutine(EnemySpawnCoroutine(5, 3f));

    }

    private IEnumerator EnemySpawnCoroutine(int count, float time)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(time);

            enemySpawner.SpawnEnemy();
        }
    }


}
