using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameObject winText;
    bool endMove = false;
    int moveDirection = 3;
    // Start is called before the first frame update
    void Start()
    {
        //if sliding is in level
        if(GameObject.FindGameObjectsWithTag("sliders").Length > 0)
        {
            endMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (endMove == true)
        {
            gameObject.transform.Translate(moveDirection * Time.deltaTime, 0, 0);
        }
    }

    void FixedUpdate ()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            winText.SetActive(true);
        }
        if(other.gameObject.name == "pointL")
        {
            moveDirection = 3;
        }
        if (other.gameObject.name == "pointR")
        {
            moveDirection = -3;
        }
    }
}
