using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDown()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
