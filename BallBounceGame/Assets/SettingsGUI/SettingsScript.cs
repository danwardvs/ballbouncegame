using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour


{
    Button control_button;
    Button sfx_button;
    Button music_button;

    bool control_state = false;
    bool sfx_enabled = true;
    bool music_enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        control_button = GameObject.Find("ControlButton").GetComponent<Button>();
        sfx_button = GameObject.Find("SFXButton").GetComponent<Button>();
        music_button = GameObject.Find("MusicButton").GetComponent<Button>();

    }
    public void ControlButtonPressed(){
        control_state = !control_state;

        ColorBlock new_cb = control_button.colors;
        string new_text;


        if(control_state){
            new_cb.normalColor = Color.red;
            new_cb.highlightedColor = new Color(1f,0.3f,0.3f);
            new_text = "Inverted";
        }else{
            new_cb.normalColor = Color.blue;
            new_cb.highlightedColor = new Color(0.3f,0.3f,1f);
            new_text = "Direct";
        }

        control_button.colors = new_cb;
        control_button.GetComponentInChildren<Text>().text = new_text;

    }

    public void SFXButtonPressed(){
        sfx_enabled = !sfx_enabled;

        ColorBlock new_cb = sfx_button.colors;
        string new_text;


        if(sfx_enabled){
            new_cb.normalColor = Color.green;
            new_cb.highlightedColor = new Color(0.3f,1f,0.3f);
            new_text = "Yes";
        }else{
            new_cb.normalColor = Color.red;
            new_cb.highlightedColor = new Color(1f,0.3f,0.3f);
            new_text = "Mute";
        }

        sfx_button.colors = new_cb;
        sfx_button.GetComponentInChildren<Text>().text = new_text;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
