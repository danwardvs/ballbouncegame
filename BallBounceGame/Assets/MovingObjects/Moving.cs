using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    //the direction the block will move
    public sbyte horizontalDirection = 0;
    public sbyte verticalDirection = 0;

    //how fast the block moves
    public byte speedFactor = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move block horizontally
        if (horizontalDirection != 0)
        {
            gameObject.transform.Translate((speedFactor * horizontalDirection) * Time.deltaTime, 0, 0);
        }
        //move block vertically
        else if (verticalDirection != 0)
        {
            gameObject.transform.Translate(0, (speedFactor * verticalDirection) * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //left
        if (other.gameObject.name == "pointL")
        {
            horizontalDirection = 1;
            verticalDirection = 0;
        }
        //right
        else if (other.gameObject.name == "pointR")
        {
            horizontalDirection = -1;
            verticalDirection = 0;
        }
        //top box
        else if (other.gameObject.name == "pointT")
        {
            horizontalDirection = 0;
            verticalDirection = -1;
        }
        //bottom box
        else if (other.gameObject.name == "pointB")
        {
            horizontalDirection = 0;
            verticalDirection = 1;
        }
        //switch directions
        else if (other.gameObject.name == "pointS")
        {
            sbyte temp = horizontalDirection;
            horizontalDirection = verticalDirection;
            verticalDirection = temp;
        }
    }
}
