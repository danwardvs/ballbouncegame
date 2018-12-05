using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    GameObject ball_object;

	// Use this for initialization (input, etc.)
	void Start () {
        ball_object = GameObject.Find("Ball"); //gets ball gameobject
	}
	
	// Update is called once per frame (use for physics)
	void Update () {
		
	}
}
