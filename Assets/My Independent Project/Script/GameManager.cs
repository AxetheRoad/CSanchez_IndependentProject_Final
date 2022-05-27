using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    

    public Button Restart;
    public bool gameActive = false;
    private GameManager gameManager;
    public GameObject titleScreen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
       gameActive = true;
        titleScreen.gameObject.SetActive(false);
        player.SetActive(true);


    }

    public void GameOver()
    {
        gameActive = false;
        player.SetActive(false);
        gameOver.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);

    }

   

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
