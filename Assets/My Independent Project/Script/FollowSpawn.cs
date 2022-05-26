using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 24.0f;
    private int enemyCount;
    private int waveNumber = 1;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnWave(waveNumber);
    }

    private void Update()
    {
        if (gameManager.gameActive == true)
        {
            enemyCount = FindObjectsOfType<EnemyFollows>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnWave(waveNumber);
            }
        }
           
    }
    void SpawnWave(int enemyNum)
    {
        if(gameManager.gameActive == true)
        {
          Instantiate(powerUpPrefab, PowerSpawn(), powerUpPrefab.transform.rotation);

            for (int i = 0; i < enemyNum; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
        

       
        // Vector3 genPos = GenerateSpawnPosition();
    }
    Vector3 GenerateSpawnPosition()
    {

        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
        return spawnPos;
    }
    Vector3 PowerSpawn()
    {

        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos, 0.7f, zPos);
        return spawnPos;
    }
    // Update is called once per frame

}