using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameScript : MonoBehaviour
{
    // References to gameObjects that are used by this gameObject
    public GameObject GameBallPrefab;
    GameObject GameBallInstance;
    GameObject arrowObject;
    GameObject InitialClickIndicator;
    GameObject DistanceIndicator;

    // We store a reference to this so we can change colour without re-getting the object
    SpriteRenderer m_SpriteRenderer;

    Text gameText;

    // Variables for the click and drag
    bool is_clicked = false;
    bool level_finish = false;
    bool invert_controls = false;
    Vector2 new_force;
    Vector2 mouse_location;
    Vector2 initial_click;
    
    public void SetLevelFinish(bool newFinish)
    {
        level_finish = newFinish;
    }

    void HandleClick(){
        is_clicked = true;
        initial_click = mouse_location;
        InitialClickIndicator.transform.position = mouse_location;
        DistanceIndicator.transform.position = mouse_location;

    }
    
    // Start is called before the first frame update
    void Start()
    {   

        // Load inverted controls from PlayerPrefs, which is stored in a local
        // file and is set by the settings menu. 
        if(PlayerPrefs.GetInt("Control", 1)==0){
            invert_controls = true;
        }
        //Grab a reference to the sprite renderer so we can manipulate the colour later on
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // Snag a reference to the children for later use
        arrowObject = GameObject.Find("arrow");
        InitialClickIndicator = GameObject.Find("InitialTouch");
        DistanceIndicator = GameObject.Find("DistanceIndicator");

        // The text object that should be included with every level
        gameText = GameObject.Find("ShotText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        // Little thing to test out inverted control scheme
        if(Input.GetKeyDown("space")){
            invert_controls=!invert_controls;
        }

        if (!level_finish)
        {
            // Update mouse location, this is used later on in the update loop
            mouse_location = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            // Check if a touch has happened
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Ignore touch if pressing on a UI element
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    HandleClick();

                }
            }

            // Check if a mouse click has happened
            else if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                HandleClick();
            }

            // Handles left click being released
            if (Input.GetMouseButtonUp(0))
            {
                if (is_clicked)
                {
                    // If game start object was being clicked and dragged, spawn a game ball
                    GameBallInstance = Instantiate(GameBallPrefab, transform);
                    GameBallInstance.GetComponent<Rigidbody2D>().AddForce(new_force * 100);
                }

                is_clicked = false;

            }
            if (is_clicked)
            {
                // Calculate a force based on mouse location and game start object position
                new_force = new Vector2(initial_click.x, initial_click.y) - mouse_location;

                if(!invert_controls){
                    new_force = new_force*-1;
                }

                // Limit power to abritary value given here
                float max_force = 7;

                if (new_force.magnitude > max_force)
                    new_force = new_force * (max_force / new_force.magnitude);

                // We use MATH and FUNCTIONS to find angles
                float new_angle = 90 + -57 * Mathf.Atan2(new_force.x, new_force.y);

                // Set the rotation of the arrow to show current trajectory of ball
                arrowObject.transform.eulerAngles = new Vector3(0, 0, new_angle);

                // Set scale of arrow to show power
                float min_scale = 0.3f;
                float scale_rate = 0.15f;
                arrowObject.transform.localScale = new Vector2(min_scale + new_force.magnitude * scale_rate, min_scale + new_force.magnitude * scale_rate);

                // Properly scale the image to match the mouse location
                float distance_scale = 0.2f; 
                DistanceIndicator.transform.localScale = new Vector2(new_force.magnitude*distance_scale,new_force.magnitude*distance_scale);


                // Set colour of arrow to show power
                arrowObject.GetComponent<SpriteRenderer>().color = new Color((1f / 7f) * new_force.magnitude, 1f - (1f / 7f) * new_force.magnitude, 0f);

                // Set visual cues on the base object (triangle)
                m_SpriteRenderer.color = Color.red;
                arrowObject.SetActive(true);
                InitialClickIndicator.SetActive(true);
                DistanceIndicator.SetActive(true);

                gameText.enabled = true;

                // Update GUI to reflect the current shot vector
                gameText.text = "Power:" + new_force.magnitude.ToString("#.#") + "\nAngle:" + new_angle.ToString("#");


            }
            else
            {
                // Reset visual cues
                m_SpriteRenderer.color = Color.green;
                arrowObject.SetActive(false);
                InitialClickIndicator.SetActive(false);
                DistanceIndicator.SetActive(false);


                gameText.enabled = false;

            }
        }
        else
        {
            arrowObject.SetActive(false);
            gameText.enabled = false;
            m_SpriteRenderer.enabled = false;
        }
    }
}
