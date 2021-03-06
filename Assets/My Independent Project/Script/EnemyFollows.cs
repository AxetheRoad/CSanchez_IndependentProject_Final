using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour
{
    Rigidbody enemyRB;
    GameObject player;
    public float speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            Vector3 seekDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(seekDirection * speed * Time.deltaTime);
        }
        
    }
}
