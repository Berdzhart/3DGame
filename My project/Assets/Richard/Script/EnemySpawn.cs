using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; 
    [SerializeField] float xClampRange = 5f; 
    [SerializeField] float yClampRange = 5f;

    int[] enemiesPerLevel = { 15, 30, 50 }; 
    int currentLevel = 0; 
    int enemiesSpawned = 0; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentLevel < enemiesPerLevel.Length)
        {
            int totalEnemies = enemiesPerLevel[currentLevel];
            enemiesSpawned = 0;

            while (enemiesSpawned < totalEnemies)
            {
                
                float spawnInterval = (enemiesSpawned < totalEnemies / 2) ? Random.Range(5f, 7f) : Random.Range(4f, 5f);

                SpawnEnemy();
                enemiesSpawned++;

                yield return new WaitForSeconds(spawnInterval);
            }

            
            yield return new WaitForSeconds(3f);
            currentLevel++;
        }

    
    }

    void SpawnEnemy()
    {
        float spawnX = Random.Range(-xClampRange, xClampRange);
        float spawnY = Random.Range(-yClampRange, yClampRange);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 30f); // Spawn di depan player

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}