using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float zPositionRange = 24;

    private GameManager gameManager;
 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 3.0f, 1.5f);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void SpawnRandomEnemy()
    {
        float RanZPos = Random.Range(-zPositionRange, zPositionRange);
        Vector3 RanPos = new Vector3(-24, 0,RanZPos);

        if (gameManager.gameActive == true)
        {
            Instantiate(enemyPrefabs, RanPos,
           enemyPrefabs.transform.rotation);
        }
           

    }
}
