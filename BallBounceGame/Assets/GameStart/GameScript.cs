using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    // References to gameObjects that are used by this gameObject
    public GameObject GameBallPrefab;
    GameObject GameBallInstance;
    GameObject arrowObject;

    // We store a reference to this so we can change colour without re-getting the object
    SpriteRenderer m_SpriteRenderer;

    // Variables for the click and drag
    bool is_clicked = false;
    Vector2 new_force;
    Vector2 mouse_location;
    

    
    // Start is called before the first frame update
    void Start()
    {
        //Grab 
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.green;

        arrowObject = GameObject.Find("arrow");



    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouse_location = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));


        if (Input.GetMouseButtonDown(0))
        {

            // Hitbox for location of game start object, (currently is triangle)
            float width = 2;
            float height = 2;


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

            // We use MATH and FUNCTIONS to find angles
            float newAngle = 90 + -57 * Mathf.Atan2(new_force.x, new_force.y);
            
            // Set the rotation of the arrow to show current trajectory of ball
            arrowObject.transform.eulerAngles = new Vector3(0, 0, newAngle);


            // Set visual cues
            m_SpriteRenderer.color = Color.red;
            arrowObject.active = true;


        }
        else
        {
            // Reset visual cues
            m_SpriteRenderer.color = Color.green;
            arrowObject.active = false;

        }
    }
}
