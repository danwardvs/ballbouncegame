using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadLevel(int newLevel)
    {
        // Since the level select and title screen come before the game levels in the build level list, we add one to it
        newLevel += 1;
        SceneManager.LoadScene(newLevel, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
