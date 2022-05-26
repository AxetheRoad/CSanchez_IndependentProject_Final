using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3.0f;
    private float gravity = 9.8f;
    public float jumpSpeed = 50.0f;
    public GameObject energyBalls;
    public int maxHealth = 100;
    public int currentHealth;

    private float horizontalInput;
    private float verticalInput;

    Rigidbody rb;
    bool canJump;
    bool canDoubleJump;
    public GameObject powerUpIn;
    public float powerUpSpeed = 10.0f;

    public bool gameOver = false;
    bool hasPowerUp = false;

    private AudioSource auPlayer;
    public AudioClip energySound;
    public AudioClip jumpSound;
    public AudioClip powerSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        //  enemyDamage.OnTriggerEnter(Collider other);
        auPlayer = GetComponent<AudioSource>();
        //Check playe is on the floor
    }
    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag == "Floor")
            {
                canJump = true;
            }
        

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }

    void Jump()
    {
        rb.AddForce(0f, jumpSpeed * gravity, 0f);
        auPlayer.PlayOneShot(jumpSound, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


        
       
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
            {
              
                Jump();
                canDoubleJump = true;
                

            }
             else if (canDoubleJump)
            {
                jumpSpeed = jumpSpeed / 1.5f;
                Jump();
                canDoubleJump = false;
                jumpSpeed = jumpSpeed * 1.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            auPlayer.PlayOneShot(energySound, 1.0f);
            Instantiate(energyBalls, transform.position, energyBalls.transform.rotation);
            
        }

        if (currentHealth <= 0)
        {
            gameOver = true;
            Debug.Log("FINAL");
            Destroy(gameObject);
        }
     

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            speed = powerUpSpeed + speed;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            auPlayer.PlayOneShot(powerSound, 1.0f);
            powerUpIn.SetActive(true);
        }

    }
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        speed = speed - powerUpSpeed;
        powerUpIn.SetActive(false);
    }
}
