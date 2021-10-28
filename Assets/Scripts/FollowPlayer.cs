using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(-3.0f, 2.0f, 0.0f);

    //private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = player.transform.position + offset;
        // //transform.Rotate(Vector3.up, ) = player.transform.rotation.y;
        // if(Input.GetKeyDown(KeyCode.Q))
        // {
        //     FlipCamera();
        // }
    }

    void FlipCamera()
    {
        transform.Rotate(Vector3.up, 180, Space.World);
        offset[0] *= -1;
        //playerControllerScript.speed *= -1;
    }
}
