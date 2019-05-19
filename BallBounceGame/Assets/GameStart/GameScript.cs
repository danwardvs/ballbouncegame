using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    // References to gameObjects that are used by this gameObject
    public GameObject GameBallPrefab;
    GameObject GameBallInstance;
    GameObject arrowObject;

    // We store a reference to this so we can change colour without re-getting the object
    SpriteRenderer m_SpriteRenderer;

    Text gameText;

    // Variables for the click and drag
    bool is_clicked = false;
    bool level_finish = false;
    Vector2 new_force;
    Vector2 mouse_location;
    
    public void SetLevelFinish(bool newFinish)
    {
        level_finish = newFinish;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Grab a reference to the sprite renderer so we can manipulate the colour later on
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // Snag a reference to the arrow for later use
        arrowObject = GameObject.Find("arrow");

        // The text object that should be included with every level
        gameText = GameObject.Find("ShotText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!level_finish)
        {
            // Update mouse location, this is used later on in the update loop
            Vector2 mouse_location = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));


            if (Input.GetMouseButtonDown(0))
            {

                // Hitbox for location of game start object, (currently is triangle)
                float width = 20;
                float height = 20;


                // Simple AABB collision for clicking on the game start object
                is_clicked = (mouse_location.x > transform.position.x - width / 2 && mouse_location.x < transform.position.x + width / 2
                    && mouse_location.y > transform.position.y - height / 2 && mouse_location.y < transform.position.y + height / 2);

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
                new_force = new Vector2(transform.position.x, transform.position.y) - mouse_location;

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

                // Set colour of arrow to show power
                arrowObject.GetComponent<SpriteRenderer>().color = new Color((1f / 7f) * new_force.magnitude, 1f - (1f / 7f) * new_force.magnitude, 0f);

                // Set visual cues on the base object (triangle)
                m_SpriteRenderer.color = Color.red;
                arrowObject.SetActive(true);
                gameText.enabled = true;

                // Update GUI to reflect the current shot vector
                gameText.text = "Power:" + new_force.magnitude.ToString("#.#") + "\nAngle:" + new_angle.ToString("#");


            }
            else
            {
                // Reset visual cues
                m_SpriteRenderer.color = Color.green;
                arrowObject.SetActive(false);
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
