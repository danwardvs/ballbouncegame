using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsScript : MonoBehaviour


{
    Button control_button;
    Button sfx_button;
    Button music_button;

    bool control_state = true;
    bool sfx_enabled = true;
    bool music_enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        // Find references to the buttons for later use
        control_button = GameObject.Find("ControlButton").GetComponent<Button>();
        sfx_button = GameObject.Find("SFXButton").GetComponent<Button>();
        music_button = GameObject.Find("MusicButton").GetComponent<Button>();
        
        // Load player settings from file and set the buttons accordlingly
        if(PlayerPrefs.GetInt("Control", 1)==0)
            ControlButtonPressed();

        if(PlayerPrefs.GetInt("Music", 1)==0)
            MusicButtonPressed();
        
        if(PlayerPrefs.GetInt("Sound", 1)==0)
            SFXButtonPressed();
        

    }
    public void ControlButtonPressed(){

        control_state = !control_state;

        PlayerPrefs.SetInt("Control", control_state ? 1 : 0);

        ColorBlock new_cb = control_button.colors;
        string new_text;

        if(!control_state){
            new_cb.normalColor = Color.red;
            new_cb.highlightedColor = new Color(1f,0.3f,0.3f);
            new_text = "INVERTED";
        }else{
            new_cb.normalColor = Color.blue;
            new_cb.highlightedColor = new Color(0.3f,0.3f,1f);
            new_text = "DIRECT";
        }

        control_button.colors = new_cb;
        control_button.GetComponentInChildren<Text>().text = new_text;

    }
    public void BackButtonPressed(){

        // Return to main menu and save settings
        PlayerPrefs.Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);


    }
    public void MusicButtonPressed(){

        music_enabled = !music_enabled;

        PlayerPrefs.SetInt("Music", music_enabled ? 1 : 0);

        ColorBlock new_cb = music_button.colors;
        string new_text;

        if(music_enabled){
            new_cb.normalColor = Color.green;
            new_cb.highlightedColor = new Color(0.3f,1f,0.3f);
            new_text = "YES";
        }else{
            new_cb.normalColor = Color.red;
            new_cb.highlightedColor = new Color(1f,0.3f,0.3f);
            new_text = "MUTE";
        }

        music_button.colors = new_cb;
        music_button.GetComponentInChildren<Text>().text = new_text;

    }

    public void SFXButtonPressed(){

        sfx_enabled = !sfx_enabled;

        PlayerPrefs.SetInt("Sound", sfx_enabled ? 1 : 0);

        ColorBlock new_cb = sfx_button.colors;
        string new_text;

        if(sfx_enabled){
            new_cb.normalColor = Color.green;
            new_cb.highlightedColor = new Color(0.3f,1f,0.3f);
            new_text = "YES";
        }else{
            new_cb.normalColor = Color.red;
            new_cb.highlightedColor = new Color(1f,0.3f,0.3f);
            new_text = "MUTE";
        }

        sfx_button.colors = new_cb;
        sfx_button.GetComponentInChildren<Text>().text = new_text;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
