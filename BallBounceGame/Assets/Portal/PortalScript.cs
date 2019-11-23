using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This allows us to see the changes made by the colour choice in the editor
[ExecuteInEditMode]

public class PortalScript : MonoBehaviour
{
    GameObject sibling_portal_collider;
    GameObject sibling_portal;
    Color portal_colour;

    // Start is called before the first frame update

    
    void Start()
    {
        
        // Get the colour that is set by a public variable by the parent
        portal_colour = gameObject.transform.parent.GetComponent<PortalParentScript>().portal_colour;
        //portal_colour = Color.red;
        this.transform.Find("Light_Area").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().color = portal_colour;
        Color block_colour = new Color(portal_colour.r,portal_colour.g,portal_colour.b);
        
        this.transform.Find("RightWall").GetComponent<SpriteRenderer>().color = block_colour;
        this.transform.Find("LeftWall").GetComponent<SpriteRenderer>().color = block_colour;
        this.transform.Find("BackWall").GetComponent<SpriteRenderer>().color = block_colour;
        this.transform.Find("Inner").GetComponent<SpriteRenderer>().color = portal_colour;


        // Find the sibling portal and store a reference for teleportation of the ball

        if (gameObject.name == "Portal_1")
        {
            sibling_portal = gameObject.transform.parent.Find("Portal_2").gameObject;
            sibling_portal_collider = gameObject.transform.parent.Find("Portal_2/Inner").gameObject;



        }
        else
        {
            sibling_portal = gameObject.transform.parent.Find("Portal_1").gameObject;
            sibling_portal_collider = gameObject.transform.parent.Find("Portal_1/Inner").gameObject;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            // Get reference to the ball that collides with the portal
            Rigidbody2D colliding_ball_rb = other.gameObject.GetComponent<Rigidbody2D>();

            // Teleport the ball to the sibling portal
            other.gameObject.transform.position = sibling_portal_collider.transform.position;

            // Find our angle and magnitude of velocity
            float new_angle = sibling_portal.transform.rotation.eulerAngles.z;
            float colliding_ball_speed = colliding_ball_rb.velocity.magnitude;

            // Add 90 degrees because the portals are pointing up at their 0 degrees
            new_angle += 90;

            // Using some trig, we find the new velocity for the ball
            Vector3 new_velocity = new Vector3(Mathf.Cos(new_angle*Mathf.Deg2Rad) * colliding_ball_speed, Mathf.Sin(new_angle*Mathf.Deg2Rad) * colliding_ball_speed, 0);


            // Give the ball the newly calculated velocity
            colliding_ball_rb.velocity = new_velocity;

        }
    }
}
