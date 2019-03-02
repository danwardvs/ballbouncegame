using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUIscript : MonoBehaviour
{

    Button restart_button;

    void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);


    }

    public void RestartButtonClicked()
    {
        print("button pressed!!");
        restartLevel();

    }
    // Start is called before the first frame update
    void Start()
    {

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
