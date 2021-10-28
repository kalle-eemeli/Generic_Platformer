using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light thisLight;
    
    // Start is called before the first frame update
    void Start()
    {   
        thisLight = this.GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flicker()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 1.0f));
            thisLight.enabled = ! thisLight.enabled;

        }
    }
}
