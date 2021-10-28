using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public bool CPisActive;
    public Vector3 CPpos;
    public GameObject cpnot;
    GameManager gameManager;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        CPisActive = false;
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && CPisActive != true)
        {
            CPisActive = true;
            CPpos = other.gameObject.transform.position;
            playerController.playerSpawnPos = CPpos;
            StartCoroutine(Notification());
        }
    }

    IEnumerator Notification()
    {
        cpnot.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cpnot.SetActive(false);
    }
   
}
