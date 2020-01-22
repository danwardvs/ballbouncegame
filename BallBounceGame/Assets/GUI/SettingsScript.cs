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
    Button debug_draw_button;
    Button fps_lock_button;
    Button graphics_button;

    bool control_state = true;
    bool sfx_enabled = true;
    bool music_enabled = true;
    bool debug_draw = false;
    int fps_lock = 60;
    int[] fps_list = { 30, 60, 120, 144, 1000 };
    string[] GRAPHIC_LEVELS = { "VERY LOW","LOW","MEDIUM","HIGH" };


    // Start is called before the first frame update
    void Start()
    {
        // Find references to the buttons for later use
        control_button = GameObject.Find("ControlButton").GetComponent<Button>();
        sfx_button = GameObject.Find("SFXButton").GetComponent<Button>();
        music_button = GameObject.Find("MusicButton").GetComponent<Button>();
        debug_draw_button = GameObject.Find("DebugDrawButton").GetComponent<Button>();
        fps_lock_button = GameObject.Find("FPSLockButton").GetComponent<Button>();
        graphics_button = GameObject.Find("GraphicsButton").GetComponent<Button>();



        // Load player settings from file and set the buttons accordlingly

        graphics_button.GetComponentInChildren<Text>().text = GRAPHIC_LEVELS[QualitySettings.GetQualityLevel()];


        if (PlayerPrefs.GetInt("Control", 1) == 0)
            ControlButtonPressed();

        if (PlayerPrefs.GetInt("Music", 1) == 0)
            MusicButtonPressed();

        if (PlayerPrefs.GetInt("Sound", 1) == 0)
            SFXButtonPressed();

        if (PlayerPrefs.GetInt("DebugDraw", 0) == 1)
            DebugDrawButtonPressed();

        fps_lock = PlayerPrefs.GetInt("FPSLock",60);

        if (fps_lock == 1000)
            fps_lock_button.GetComponentInChildren<Text>().text = "UNLOCKED";
        else
            fps_lock_button.GetComponentInChildren<Text>().text = fps_lock.ToString();

    }
    public void FPSButtonPressed()
    {
  
        // Handling cases of custom fps locks manually set in the config file
        bool found = false;
        for(int i=0; i<fps_list.GetLength(0); i++)
        {
            
            if (fps_lock == fps_list[fps_list.GetLength(0)-1])
            {
                fps_lock = fps_list[0];
                found = true;
                break;
            }
            else if (fps_lock == fps_list[i])
            {
                fps_lock = fps_list[i + 1];
                found = true;
                break;

            }

        }
        if (!found)
        {
            fps_lock = fps_list[0];
        }

        if (fps_lock == 1000)
            fps_lock_button.GetComponentInChildren<Text>().text = "UNLOCKED";
        else
            fps_lock_button.GetComponentInChildren<Text>().text = fps_lock.ToString();

        PlayerPrefs.SetInt("FPSLock", fps_lock);
        Application.targetFrameRate = fps_lock;
    }
    public void GraphicsButtonPressed()
    {
        int new_level = QualitySettings.GetQualityLevel();
        new_level--;
        if (new_level == -1)
            new_level = 3;
        QualitySettings.SetQualityLevel(new_level,true);

        graphics_button.GetComponentInChildren<Text>().text = GRAPHIC_LEVELS[new_level];

    }

    public void ControlButtonPressed()
    {

        control_state = !control_state;

        PlayerPrefs.SetInt("Control", control_state ? 1 : 0);
        ToggleButton(control_button, control_state, new string[] { "DIRECT", "INVERTED" });


    }
    public void DebugDrawButtonPressed(){
        debug_draw = !debug_draw;

        PlayerPrefs.SetInt("DebugDraw", debug_draw ? 1 : 0);
        ToggleButton(debug_draw_button, debug_draw, new string[] { "YES", "NO" });


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
