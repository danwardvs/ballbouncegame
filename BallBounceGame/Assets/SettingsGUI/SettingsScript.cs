using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsScript : MonoBehaviour


{
    GameObject control_button;
    bool control_state = true;
    // Start is called before the first frame update
    void Start()
    {
        control_button = GameObject.Find("ControlButton");
    }
    public void ControlButtonPressed(){
        control_state = !control_state;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
