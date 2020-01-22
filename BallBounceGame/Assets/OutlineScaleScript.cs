using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScaleScript : MonoBehaviour
{
    GameObject insideBlock;

    // Start is called before the first frame update
    [ExecuteInEditMode]
    void Awake()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        insideBlock = transform.Find("InsideBlock").gameObject;
        insideBlock.transform.localScale = new Vector3(0.9f + (0.1f -0.1f/x) ,0.9f + (0.1f -0.1f/y),1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
