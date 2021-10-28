using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject Player;
    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    // void OnTriggerEnter(Collider other)
    // {
    //     float strenght = 10.0f;
    //     if(other.gameObject.CompareTag("Player"))
    //     {
    //         playerRb.AddForce(Vector3.up * strenght  +  -Physics.gravity, ForceMode.Impulse);
    //     }
    // }

    void OnCollisionEnter(Collision other)
    {
        float strenght = 10.0f;
        if(other.gameObject.CompareTag("Player"))
        {
            playerRb.AddForce(Vector3.up * strenght, ForceMode.Impulse);
        }
    }
}
