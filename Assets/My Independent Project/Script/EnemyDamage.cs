using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;


    void Start()
    {
    }

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        return;
    }

   
}
