using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer block_sprite_renderer = GetComponent<SpriteRenderer>();
        UnityEngine.Experimental.Rendering.Universal.Light2D area_light = GameObject.Find("BlockLight").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        
        area_light.color = block_sprite_renderer.color;
        print("butts");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
