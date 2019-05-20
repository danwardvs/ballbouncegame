using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    GameObject sibling_portal_collider;
    GameObject sibling_portal;



    // Start is called before the first frame update


    void Start()
    {
        // Find the sibling portal
        if (gameObject.name == "Portal_1")
        {
            sibling_portal = gameObject.transform.parent.Find("Portal_2").gameObject;
            sibling_portal_collider = gameObject.transform.parent.Find("Portal_2/Collider").gameObject;



        }
        else
        {
            sibling_portal = gameObject.transform.parent.Find("Portal_1").gameObject;
            sibling_portal_collider = gameObject.transform.parent.Find("Portal_1/Collider").gameObject;

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
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            other.gameObject.transform.position = sibling_portal_collider.transform.position;
            //rb.velocity = transform.up * rb.velocity.magnitude;

            float z = sibling_portal.transform.rotation.eulerAngles.z;
            float m = rb.velocity.magnitude;
            print(z);

            Vector3 v = new Vector3(Mathf.Sin(z*(Mathf.PI)/180) * m, Mathf.Cos(z*(Mathf.PI) / 180) * m, 0);

            print(v);



            rb.velocity = v;

        }
    }
}
