using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockQualityScript : MonoBehaviour
{
    public Material lowQualityMaterial;
    public int importanceLevel;
    // Start is called before the first frame update
    void Start()
    {
        if(QualitySettings.GetQualityLevel()<importanceLevel){

            SpriteRenderer block_sprite_renderer = GetComponent<SpriteRenderer>();
            
            block_sprite_renderer.material = lowQualityMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
