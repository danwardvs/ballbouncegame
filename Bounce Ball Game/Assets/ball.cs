using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	// Use this for initialization 
	void Start () {
       
	}
	
	// Update is called once per frame 
	void Update () {
		
	}

    //when ball collides with another 2D collider
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");

    }
}
