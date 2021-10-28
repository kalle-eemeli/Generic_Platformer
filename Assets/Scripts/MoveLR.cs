using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLR : MonoBehaviour
{
    private Rigidbody platformRb;
    public float speed = 10.0f;
    public float maxY;
    public float minY;
    // Start is called before the first frame update
    void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        //platformRb.AddForce(Vector3.forward * -speed, ForceMode.VelocityChange);
        transform.Translate(Vector3.forward * -speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= maxY)
        {
            //platformRb.AddForce(Vector3.forward * -speed, ForceMode.VelocityChange);
            transform.Translate(Vector3.forward * -speed);
        }
        else if(transform.position.z <= minY)
        {
            //platformRb.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
            transform.Translate(Vector3.forward * speed);
        }
        
    }
}
