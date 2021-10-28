using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public bool timerActive;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            time += Time.deltaTime;
 
            var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
            var seconds = time % 60;//Use the euclidean division for the seconds.
            var fraction = (time * 100) % 100;
 
            //update the label value
            timer.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
        }
        
    }
}
