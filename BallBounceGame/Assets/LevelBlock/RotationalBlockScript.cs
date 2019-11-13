using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalBlockScript : MonoBehaviour
{
    GameObject block;
    public float rotation_speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        // Get reference to parent
        block = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       // Rotate based on speed that is editable in the inspector
       // Multiply by deltatime to get framerate indepentent speeds
        block.transform.Rotate(0, 0, rotation_speed * Time.deltaTime, Space.Self);
    }
}
