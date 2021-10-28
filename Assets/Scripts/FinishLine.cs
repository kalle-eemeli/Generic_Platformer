using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public bool playerHasFinished;
    // Start is called before the first frame update
    void Start()
    {
        playerHasFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                playerHasFinished = true;
            }
        }
}
