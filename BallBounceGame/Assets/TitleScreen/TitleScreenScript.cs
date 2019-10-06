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
        Application.targetFrameRate = PlayerPrefs.GetInt("FPSLock");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings(){
        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
