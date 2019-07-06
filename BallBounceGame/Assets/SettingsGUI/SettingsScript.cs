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
        if (PlayerPrefs.GetInt("Control", 1) == 0)
            ControlButtonPressed();

        if (PlayerPrefs.GetInt("Music", 1) == 0)
            MusicButtonPressed();

        if (PlayerPrefs.GetInt("Sound", 1) == 0)
            SFXButtonPressed();


    }
    public void ControlButtonPressed()
    {

        control_state = !control_state;

        PlayerPrefs.SetInt("Control", control_state ? 1 : 0);
        ToggleButton(control_button, control_state, new string[] { "DIRECT", "INVERTED" });


    }
    public void BackButtonPressed()
    {

        // Return to main menu and save settings
        PlayerPrefs.Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);


    }
    public void MusicButtonPressed()
    {

        music_enabled = !music_enabled;
        PlayerPrefs.SetInt("Music", music_enabled ? 1 : 0);
        ToggleButton(music_button, music_enabled, new string[] { "YES", "MUTE" });

    }

    public void SFXButtonPressed()
    {
        sfx_enabled = !sfx_enabled;
        PlayerPrefs.SetInt("Sound", sfx_enabled ? 1 : 0);
        ToggleButton(sfx_button, sfx_enabled, new string[] { "YES", "MUTE" });


    }
    void ToggleButton(Button newButton, bool enabled, string[] newText)
    {

        ColorBlock new_cb = newButton.colors;
        
        new_cb.normalColor = enabled ? Color.green : Color.red;
        new_cb.highlightedColor = enabled ? new Color(0.3f, 1f, 0.3f) : new Color(1f, 0.3f, 0.3f);

        newButton.colors = new_cb;
        newButton.GetComponentInChildren<Text>().text = newText[enabled ? 0 : 1];

    }

    // Update is called once per frame
    void Update()
    {

    }
}
