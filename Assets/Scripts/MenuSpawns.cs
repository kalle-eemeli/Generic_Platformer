using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawns : MonoBehaviour
{
    public GameObject plane;
    public GameObject snowman;
    public GameObject[] sms;
    float xRange;
    float zRange;
    float offsetX = 19.87f; 
    float offsetZ = 23.96f;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = plane.GetComponent<MeshFilter>().mesh;
        xRange = mesh.bounds.size.x;
        zRange = mesh.bounds.size.z;
        StartCoroutine(CheckForSnowmen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckForSnowmen()
    {
        while(true)
        {
            float delay = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(delay);
            sms = GameObject.FindGameObjectsWithTag("Snowman");
            if(sms.Length == 0)
            {
                float xPos = Random.Range(-xRange, xRange);
                float zPos = Random.Range(-zRange, zRange);

                Vector3 SpawnPos = new Vector3(offsetX + xPos, plane.transform.position.y + 0.3f, offsetZ + zPos);
                Instantiate(snowman, SpawnPos, snowman.transform.rotation);
            }
        }
    }
}
