using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FPSCounterScript : MonoBehaviour
{

    private float updateInterval = 0.5f;
    private float accumulatedFps = 0.0f;
    private float timeLeft = 0.0f; 
    private int framesDrawn = 0;
    
    
    private bool fpsCounterEnabled = false;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = updateInterval;

        if(PlayerPrefs.GetInt("DebugDraw", 0) == 1){
            fpsCounterEnabled=true;
            gameObject.GetComponent<Text>().enabled = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // If disabled in the settings menu, we don't bother with all this jazz
        if(fpsCounterEnabled){
            timeLeft -= Time.deltaTime;
            accumulatedFps += Time.timeScale / Time.deltaTime;
            ++framesDrawn;

            // Interval ended - update GUI text and start new interval
            if (timeLeft <= 0.0)
            {
                // display two fractional digits (f2 format)
                gameObject.GetComponent<Text>().text = "" + (accumulatedFps / framesDrawn).ToString("f2");
                timeLeft = updateInterval;
                accumulatedFps = 0.0f;
                framesDrawn = 0;
            }
        }
    }
}
