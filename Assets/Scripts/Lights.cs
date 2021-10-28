using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    Light thislight;
    float delay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        thislight = gameObject.GetComponent<Light>();
        StartCoroutine(ColorChangeCD(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor()
    {
        Color temp1 = thislight.color; 
        Color newcolor = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));

        thislight.color = Color.Lerp(thislight.color, newcolor, 0.5f);
    }

    IEnumerator ColorChangeCD(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            ChangeColor();
        }
    }
}
