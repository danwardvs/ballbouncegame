using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Create buttons
        PopulateButtons(CreatePanel(), 5);
    }

    // Populate buttons
    void PopulateButtons(GameObject panel, int num)
    {
        for (int i = 0; i < num; i++)
        {
            // Create new button and assign as child
            GameObject levelButton = Instantiate(buttonPrefab, new Vector3(0, 100.0f + i * -100.0f, 0), Quaternion.identity);
            levelButton.transform.SetParent(panel.transform, false);
            levelButton.transform.localScale = new Vector3(1, 1, 1);

            // Set on click
            Button b = levelButton.GetComponent<Button>();

            if (b != null)
            {
                int t = i + 1;
                b.onClick.AddListener(() => LoadLevel(t));
            }
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
        panelTrans.pivot = new Vector2(0.5f, 0.5f);
        panelTrans.offsetMin = new Vector2(124, panelTrans.offsetMin.y);
        panelTrans.offsetMax = new Vector2(-124, panelTrans.offsetMax.y);
        panelTrans.offsetMax = new Vector2(panelTrans.offsetMax.x, -100.0f);
        panelTrans.offsetMin = new Vector2(panelTrans.offsetMin.x, 50.0f);

        Image panelImage = panel.AddComponent<Image>();
        panelImage.color = Color.black;

        return panel;
    }

    // Load level
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
