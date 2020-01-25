using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallScript : MonoBehaviour
{

    private SpriteRenderer ballSP;
    private float timer=0;
    private Sprite[] sprites;
    private int i = 0;

    // How far the ball must go before it is deleted
    const int DIST_OFF_SCREEN = 50;

    // Start is called before the first frame update
    void Start()
    {
        if(QualitySettings.GetQualityLevel()>0){
            sprites = Resources.LoadAll<Sprite>("BallSprites");
            ballSP = GetComponent<SpriteRenderer>();
        }
   
    }

    // Update is called once per frame
    void Update()
    {

        // Delete ball if no longer on screen
        if(transform.position.x>DIST_OFF_SCREEN || transform.position.x<-DIST_OFF_SCREEN || transform.position.y > DIST_OFF_SCREEN || transform.position.y<-DIST_OFF_SCREEN){
            Destroy(this.gameObject);
        } 
        if(QualitySettings.GetQualityLevel()>0){
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
}
