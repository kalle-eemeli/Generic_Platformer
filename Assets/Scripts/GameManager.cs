using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool CP1Active;
    public bool CP2Active;
    public GameObject CP1;
    public GameObject CP2;
    public GameObject CP3;
    public Vector3 playerSpawnPos; 
    public PlayerController playerController;
    public GameObject Player;
    private Rigidbody playerRb;
    private static bool s_permanentInstance = false;  // set to true if you ever only want *one* instance among all scenes and drop an instance of GameManager in your first scene you load
    public static GameManager Instance {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        
        if (s_permanentInstance == true)
        {
            if (Instance != null)
            {
                Debug.LogError( "GameManager initialized twice, overwriting" );
            }
            DontDestroyOnLoad( this );  // prevents this from being destroyed on scene load
         }
         // store the singleton reference
        Instance = this;

        playerSpawnPos = Player.transform.position;
        playerController = Player.GetComponent<PlayerController>();
        playerRb = Player.GetComponent<Rigidbody>();
        CP1.gameObject.GetComponent<Checkpoint>().CPisActive = false;
        CP2.gameObject.GetComponent<Checkpoint>().CPisActive = false;
        CP3.gameObject.GetComponent<Checkpoint>().CPisActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerSpawnPos = playerController.playerSpawnPos;
        CheckGameState();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    void CheckGameState()
    {
        if(Player.transform.position.y < 0.5f)
        {
            Debug.Log("Game Over!!");
            //Destroy(gameObject);
            
            SpawnAtCheckpoint();
            //RestartGame();
        }
    }
    public void SpawnAtCheckpoint()
    {
        playerRb.velocity = new Vector3(0,0,0);
        playerRb.angularVelocity = new Vector3(0,0,0);
        StartCoroutine(HaltPlayerMovement());
        Player.transform.position = playerController.playerSpawnPos;
    }

    IEnumerator HaltPlayerMovement()
    {
        playerController.enabled = false;
        yield return new WaitForSeconds(0.5f);
        playerController.enabled = true;
    }
}
