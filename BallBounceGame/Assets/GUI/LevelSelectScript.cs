using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject ButtonPrefab;



    // Start is called before the first frame update
    void Start()
    {
        // Create the correct amount of buttons based on the number of scenes in the build settings
        PopulateButtons(CreatePanel(), SceneManager.sceneCountInBuildSettings - Constants.NON_LEVEL_SCENES);
    }

    public void BackButtonPressed(){
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);

    }

    public void ResetSaves()
    {   
        // Rewrite all data to file
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings - Constants.NON_LEVEL_SCENES; i++)
        {
            PlayerPrefs.SetInt("Level_" + i.ToString(), 0);
            PlayerPrefs.SetInt("Level_" + i.ToString() +"_Score", 9999);

        }
        PlayerPrefs.Save();

        // Reload scene instead of resetting all buttons manually
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_scene.name);
    }
    // Generates a 2D array of buttons in a given panel
    void PopulateButtons(GameObject panel, int num)
    {
        int row = 0;
        int column = 0;

        for (int i = 0; i < num; i++)
        {
            int level = i + 1;
            CreateButton(-270.0f + column * 60.0f, -50.0f - row * 60.0f, level, panel);

            // Next row
            column++;
            if (column >= 10)
            {
                row++;
                column = 0;
            }
        }
    }

    // Creates button using a given parent 
    void CreateButton(float x, float y, int level, GameObject parent)
    {
        // Check from file if the level is complete
        bool level_complete = false;
        if (PlayerPrefs.GetInt("Level_" + level.ToString(), 0) == 1)
        {
            level_complete = true;
        }
        // Create new button and assign as child
        GameObject levelButton = Instantiate(ButtonPrefab, new Vector3(x, y, 0), Quaternion.identity);
        levelButton.transform.SetParent(parent.transform, false);
        levelButton.transform.localScale = new Vector3(1, 1, 1);

        RectTransform buttonTrans = levelButton.GetComponent<RectTransform>();
        buttonTrans.anchorMin = new Vector2(0.5f, 1.0f);
        buttonTrans.anchorMax = new Vector2(0.5f, 1.0f);

        levelButton.GetComponentInChildren<Text>().text = (level).ToString();


        // Set button colors based on completion
        if (level_complete)
        {
            Button buttonObject = levelButton.GetComponent<Button>();
            ColorBlock new_cb = buttonObject.colors;

            new_cb.normalColor = Color.green;
            new_cb.highlightedColor = new Color(0.5f, 1f, 0.5f);

            buttonObject.colors = new_cb;

        }else{
            Button buttonObject = levelButton.GetComponent<Button>();
            ColorBlock new_cb = buttonObject.colors;

            new_cb.normalColor = new Color(0.6f, 0.3f, 0.3f);
            new_cb.highlightedColor = new Color(0.8f, 0.5f, 0.5f);

            buttonObject.colors = new_cb;
        }
        // Set on click
        Button b = levelButton.GetComponent<Button>();

        if (b != null)
        {
            b.onClick.AddListener(() => LoadLevel(level));
        }
    }

    // Create panel
    GameObject CreatePanel()
    {
        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        panel.AddComponent<RectTransform>();
        panel.transform.SetParent(gameObject.transform, false);

        RectTransform panelTrans = panel.GetComponent<RectTransform>();
        panelTrans.anchorMin = new Vector2(0.0f, 0.0f);
        panelTrans.anchorMax = new Vector2(1.0f, 1.0f);
        panelTrans.offsetMin = new Vector2(90, 50.0f);
        panelTrans.offsetMax = new Vector2(-90, -130.0f);

        Image panelImage = panel.AddComponent<Image>();
        panelImage.color = new Color(0f,0f,0f,0f);

        return panel;
    }

    // Load level when level icon is pressed
    public void LoadLevel(int newLevel)
    {
        // Subtract one for zero indexing
        SceneManager.LoadScene(newLevel-1, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
