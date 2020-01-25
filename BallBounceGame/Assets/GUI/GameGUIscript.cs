using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIscript : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject endGameMenu;
    public GameObject pauseMenu;
    
    private GameScript gameScriptRef;
    
    private Text scoreText;

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
        menuButton.SetActive(false);
        endGameMenu.SetActive(true);
        Vector2 stats = gameScriptRef.GetStats();
        scoreText.text = "TIME: " + stats.x.ToString("F2") + "\nBALLS: " + stats.y.ToString();

    }

    public void LoadNextLevel()
    {

        // Loads next available level (current max of 5)
        if( SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
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
