using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    GameObject GameGUI;
    GameObject GameStart;
    UnityEngine.Experimental.Rendering.Universal.Light2D LightPoint;
    private float clock = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameGUI = GameObject.Find("GameGUI");
        GameStart = GameObject.Find("GameStart");
        LightPoint = this.transform.Find("Light_Point").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime/1f;
        LightPoint.intensity = (float)( 4 + 2.5f*Math.Sin(clock));
        

    }

    void FixedUpdate ()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            GameGUI.GetComponent<GameGUIscript>().FinishLevel();
            GameStart.GetComponent<GameScript>().SetLevelFinish(true);

        }
    }
}
