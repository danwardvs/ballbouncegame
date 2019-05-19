using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUIscript : MonoBehaviour
{
    GameObject RestartButton;
    GameObject EndGamePanel;


    void restartLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_scene.name);



    }

    public void RestartButtonClicked()
    {
        restartLevel();

    }
    public void FinishLevel()
    {
        print("level is doneeee");
        RestartButton.SetActive(false);
        EndGamePanel.SetActive(true);




    }

    public void LoadNextLevel()
    {

        // Shhh...
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4, LoadSceneMode.Single);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        RestartButton = GameObject.Find("GameGUI/RestartButton");
        EndGamePanel = GameObject.Find("GameGUI/EndGamePanel");


        EndGamePanel.SetActive(false);

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
