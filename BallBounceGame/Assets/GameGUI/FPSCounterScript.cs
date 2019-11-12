using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FPSCounterScript : MonoBehaviour
{

    float updateInterval = 0.5f;

    private float accum = 0.0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval
    
    bool enabled = false;


    // Start is called before the first frame update
    void Start()
    {
        timeleft = updateInterval;
        if(PlayerPrefs.GetInt("DebugDraw", 0) == 1){
            enabled=true;
            gameObject.GetComponent<Text>().enabled = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // If disabled in the settings menu, we don't bother with all this jazz
        if(enabled){
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;

            // Interval ended - update GUI text and start new interval
            if (timeleft <= 0.0)
            {
                // display two fractional digits (f2 format)
                gameObject.GetComponent<Text>().text = "" + (accum / frames).ToString("f2");
                timeleft = updateInterval;
                accum = 0.0f;
                frames = 0;
            }
        }
    }
}
