using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    GameObject sibling_portal;

    // Start is called before the first frame update
    void Start()
    {
        // Find the sibling portal
        if (gameObject.name == "Portal_1")
        {
            sibling_portal = gameObject.transform.parent.Find("Portal_2").gameObject;

        }
        else
        {
            sibling_portal = gameObject.transform.parent.Find("Portal_1").gameObject;
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
            other.gameObject.transform.position = sibling_portal.transform.position;

        }
    }
}
