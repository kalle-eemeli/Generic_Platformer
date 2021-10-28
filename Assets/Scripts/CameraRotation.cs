using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButton(1))
        {
            float mouseHorizontal = Input.GetAxis("Mouse X");
            Debug.Log(mouseHorizontal);

            transform.Rotate(Vector3.up, mouseHorizontal * speed * Time.deltaTime);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player
    }
}
