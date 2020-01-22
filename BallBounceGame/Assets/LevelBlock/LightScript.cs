using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public int importanceLevel=0;
    // Start is called before the first frame update
    void Start()
    {
        if(QualitySettings.GetQualityLevel()<importanceLevel)

            gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
