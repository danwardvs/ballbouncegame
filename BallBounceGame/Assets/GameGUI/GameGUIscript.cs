using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUIscript : MonoBehaviour
{
    GameObject RestartButton;
    GameObject EndGamePanel;
    GameObject PauseMenu;


    void restartLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_scene.name);
        Time.timeScale = 1f;



    }

    public void RestartButtonClicked()
    {
        restartLevel();

    }
    public void FinishLevel()
    {
        RestartButton.SetActive(false);
        EndGamePanel.SetActive(true);




    }

    public void LoadNextLevel()
    {

        // Loads next available level (current max of 5)
        if( SceneManager.GetActiveScene().buildIndex < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
       
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void UnpauseGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        RestartButton = GameObject.Find("GameGUI/RestartButton");
        EndGamePanel = GameObject.Find("GameGUI/EndGamePanel");
        PauseMenu = GameObject.Find("GameGUI/PauseMenu");



        EndGamePanel.SetActive(false);
        PauseMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) 
        {
            restartLevel();
        }
        
    }
}
