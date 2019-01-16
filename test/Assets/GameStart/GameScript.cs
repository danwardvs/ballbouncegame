using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject GameBallPrefab;
    GameObject GameBallInstance;
    bool is_clicked = false;

    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mouseLocation = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            float width = 2;
            float height = 2;

            if (mouseLocation.x > transform.position.x - width / 2 && mouseLocation.x < transform.position.x + width / 2
                && mouseLocation.y > transform.position.y - height / 2 && mouseLocation.y < transform.position.y + height / 2)
            {
            
                is_clicked = true;
            }
            else
            {
                is_clicked = false;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (is_clicked)
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 newForce = new Vector2(transform.position.x, transform.position.y) - target;

                GameBallInstance = Instantiate(GameBallPrefab, transform);
                GameBallInstance.GetComponent<Rigidbody2D>().AddForce(newForce * 100);
            }
            is_clicked = false;
    
            
            
        }
        if (is_clicked)
        {
            m_SpriteRenderer.color = Color.red;

        }
        else
        {
            m_SpriteRenderer.color = Color.green;

        }
    }
}
