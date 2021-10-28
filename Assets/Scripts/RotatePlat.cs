using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlat : MonoBehaviour
{
    float rotationSpeed = 8.0f;
    // public float amplitude = 10f;
	// public float frequency = 0.005f;
    // Start is called before the first frame update
    // "Bobbing" animation from 1D Perlin noise.

    // Range over which height varies.
    float heightScale = 1.0f;
    float offsetY = -1.0f;
    // Distance covered per second along X axis of Perlin plane.
    float xScale = 0.8f;
    void Start()
    {
        //heightScale  = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
        foreach(Transform child in transform)
        {
            
            // Vector3 posOffset = new Vector3 ();
	        // Vector3 tempPos = new Vector3 ();

            // posOffset = child.transform.position;

            child.Rotate(0,-rotationSpeed*Time.deltaTime,0);
            
            float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0f);
            Vector3 pos = child.transform.position;
            pos.y = transform.position.y + offsetY + height;
            child.transform.position = pos;
        }
    }
}
