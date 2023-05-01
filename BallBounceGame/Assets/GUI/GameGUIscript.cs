using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameGUIscript : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject endGameMenu;
    public GameObject pauseMenu;
    public GameObject tipText; 

    
    private GameScript gameScriptRef;
    
    private Text scoreText;
    public Text highscoreText; 
    public Text pauseMenuHighscoreText;


    void RestartLevel()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_scene.name);
        Time.timeScale = 1f;
    }

    public void RestartButtonClicked()
    {
        RestartLevel();
    }

    public void FinishLevel()
    {
        tipText.SetActive(false);
        menuButton.SetActive(false);
        endGameMenu.SetActive(true);

        // Hide next level button if on final level
        if(SceneManager.GetActiveScene().buildIndex == Constants.FINAL_LEVEL_SCENE_BUILD_INDEX)
            GameObject.Find("GameGUI/EndGameMenu/Next").SetActive(false);
        else
            GameObject.Find("GameGUI/EndGameMenu/Next").SetActive(true);


        Vector2 stats = gameScriptRef.GetStats();
        scoreText.text = "TIME: " + stats.x.ToString("F2") + "\nBALLS: " + stats.y.ToString();

        highscoreText.text=gameScriptRef.GetHighscore();
        

    }

    public void LoadNextLevel()
    {

        // Loads next available level 
        if( SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - Constants.NON_LEVEL_SCENES)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
       
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        tipText.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        
        tipText.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    { 
        Time.timeScale = 1f;
        endGameMenu.SetActive(false);
        pauseMenu.SetActive(false);
        scoreText = transform.Find("EndGameMenu/ScoreText").GetComponent<Text>();
        
        // Converts scene name like "Level_01" into an integer of "1"
        int level_number = Int32.Parse(SceneManager.GetActiveScene().name.Substring(6));

        string new_tip_text = "";

        switch(level_number){
            case 1:
                new_tip_text = "Press anywhere to drag and launch a ball. Hit the star to complete the level";
                break;
            case 3:
                new_tip_text = "Power can be changed based on the drag distance";
                break;
            case 4:
                new_tip_text = "Press Menu then Restart to reset the level";
                break;
            case 6:
                new_tip_text = "Blue blocks are movable";
                break;
            case 9:
                new_tip_text = "Red blocks are bouncy";
                break;
            case 13:
                new_tip_text = "Portals carry the ball's momentum";
                break;
            case 16:
                new_tip_text = "Yellow blocks rotate";
                break;

        }
        tipText.GetComponent<Text>().text = new_tip_text;

        int level_num = SceneManager.GetActiveScene().buildIndex;
        int prev_highscore = PlayerPrefs.GetInt("Level_"+ level_num.ToString() +"_Score", 9999);
        
        if(prev_highscore!=9999)
            pauseMenuHighscoreText.text = "HIGHSCORE: " + prev_highscore.ToString();

       
        // Get reference to main game script to pull stats from later in the endgame screen
        gameScriptRef = GameObject.Find("GameStart").GetComponent<GameScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) 
        {
            RestartLevel();
        }
    }
}
