using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Load fps locking settings from file
        Application.targetFrameRate = PlayerPrefs.GetInt("FPSLock",60);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings(){
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Single);

    }
    public void OpenCredits(){
        SceneManager.LoadScene("CreditsScreen", LoadSceneMode.Single);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
