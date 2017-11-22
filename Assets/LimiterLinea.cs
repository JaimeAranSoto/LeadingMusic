using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiterLinea : MonoBehaviour
{
    public Collider2D col;
    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
            {
                transform.position = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(touch.position).y);
            }
        }
    }
}
