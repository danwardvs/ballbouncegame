using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject ButtonPrefab;

    // Since the title screen, level select, and options screen come before
    // the first levels in the build settings, the first actual level starts at scene number 3
    const int LEVEL_START = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Create the correct amount of buttons based on the number of scenes in the build settings
        PopulateButtons(CreatePanel(), SceneManager.sceneCountInBuildSettings - LEVEL_START);
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
        // Create new button and assign as child
        GameObject levelButton = Instantiate(ButtonPrefab, new Vector3(x, y, 0), Quaternion.identity);
        levelButton.transform.SetParent(parent.transform, false);
        levelButton.transform.localScale = new Vector3(1, 1, 1);

        RectTransform buttonTrans = levelButton.GetComponent<RectTransform>();
        buttonTrans.anchorMin = new Vector2(0.5f, 1.0f);
        buttonTrans.anchorMax = new Vector2(0.5f, 1.0f);

        levelButton.GetComponentInChildren<Text>().text = (level).ToString();

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
        panelImage.color = Color.black;

        return panel;
    }

    // Load level
    public void LoadLevel(int newLevel)
    {
        newLevel += LEVEL_START - 1;
        SceneManager.LoadScene(newLevel, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
