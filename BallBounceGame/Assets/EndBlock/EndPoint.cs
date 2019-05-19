using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    GameObject GameGUI;
    // Start is called before the first frame update
    void Start()
    {
        GameGUI = GameObject.Find("GameGUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate ()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            GameGUI.GetComponent<GameGUIscript>().FinishLevel();

        }
    }
}
