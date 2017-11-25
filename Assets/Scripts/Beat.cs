using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public float speed;
    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;
    private bool limit;
    // Use this for initialization
    void Start()
    {
        limit = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0 - speed * Time.deltaTime);

        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)
        if (limit)
        {
            if (Input.touchCount > 0)
            {
                {
                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        if (Input.GetTouch(i).phase == touchPhase)
                        {
                            //We transform the touch position into word space from screen space and store it.

                            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                            //We now raycast with this information. If we have hit something we can process it.
                            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                            if (hitInformation.collider != null)
                            {
                                //We should have hit something with a 2D Physics collider!
                                GameObject touchedObject = hitInformation.transform.gameObject;
                                //touchedObject should be the object someone touched.
                                if (touchedObject == gameObject)
                                    DestroyBeat();

                            }
                        }
                    }
                }
            }

        }
    }
    void DestroyBeat()
    {
        RythmManager.Instance.currentQuality += 5;
       
        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        if (limit)
            DestroyBeat();
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        limit = true;

    }
}
