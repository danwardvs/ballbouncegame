using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallScript : MonoBehaviour
{

    private SpriteRenderer ballSP;
    private float timer=0;
    private Sprite[] sprites;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
       ballSP = GetComponent<SpriteRenderer>();
       sprites = Resources.LoadAll<Sprite>("orb3");
        print(sprites.Length);

    }

    // Update is called once per frame
    void Update()
    {
       
        timer+=Time.deltaTime*Random.Range(0.2f, 1.8f);
        if (timer > 0.1f) {
            i++;
            if (i == sprites.Length) { 
             i = 0;
            }
            timer = 0;
            ballSP.sprite = sprites[i];

        }
}
}
