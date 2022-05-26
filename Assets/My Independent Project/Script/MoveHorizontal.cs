using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    private Animator animSlime;
    public float speed = 10.0f;
    public bool enemyStop = false;
    private AudioSource auSlime;
    public AudioClip attackSound;
    public AudioClip dieSound;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animSlime = GetComponent<Animator>();
        auSlime = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.gameActive == true)
        {
      
            transform.Translate(Vector3.left* Time.deltaTime * speed);
        }
            
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.name == "Player")

        {
            animSlime.SetTrigger("Attack");
            auSlime.PlayOneShot(attackSound, .5f);
        }
    }


    public void destroy()
    {
        enemyStop = true;
        auSlime.PlayOneShot(dieSound, 0.7f);
        animSlime.SetBool("Die", true);
        Destroy(gameObject, 2f);
    }

}
