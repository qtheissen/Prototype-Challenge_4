using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {   
        // Spawn an enemy and a powerup at the start of the game
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn = 1)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Create enemyPrefab object at a random location
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);    
        }
    }
    void Update()
    {
        // Check how many enemies are in the scene
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // Spawn enemy wave when no enemies are left
        if (enemyCount == 0)
        {
            // Increase the wave number
            waveNumber ++ ;
            // Spawn a new powerup and delete the old one
            GameObject powerupToDelete = GameObject.FindGameObjectWithTag("Powerup");
            Destroy(powerupToDelete);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

            // Spawn amount of enemies according to wavenumber
            SpawnEnemyWave(waveNumber);
            
        } 
    }

    private Vector3 GenerateSpawnPosition ()
    {
        // Generate a random x and z value within the spawnRange
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        // Put random values in a vector3
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;

    }
}
