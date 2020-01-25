using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class OutlineScaleScript : MonoBehaviour
{
    GameObject insideBlock;

    // Smaller value makes larger outlines
    const float OUTLINE_SIZE = 0.85f;

    // Start is called before the first frame update
    
    void Start()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        insideBlock = transform.Find("InsideBlock").gameObject;
        Vector3 new_scale = new Vector3(OUTLINE_SIZE + ((1-OUTLINE_SIZE) - (1-OUTLINE_SIZE)/x),OUTLINE_SIZE + ((1-OUTLINE_SIZE) - (1-OUTLINE_SIZE)/y));
        insideBlock.transform.localScale = new_scale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
