using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplerPad : TimeLine
{
    private Animator anim;
    public bool isNext;
    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        isNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkInput() && isNext)
        {
            anim.SetTrigger("Pulsado");
            RythmManager.Instance.currentQuality += 10;
            anim.SetBool("TieneSample", false);
            isNext = false;
        }
    }
    public override void Stop()
    {
        anim.SetTrigger("Cancel");
        anim.SetBool("TieneSample", false);
    }
    public override void Beat(double sampleTime)
    {
        if (isNext)
        {
            anim.SetTrigger("Beat");
        }
    }
    public void SetNext()
    {
        isNext = true;
        anim.SetBool("TieneSample", true);
    }
    bool checkInput()
    {
        if (Input.touchCount > 0)
        {
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == touchPhase)
                    {
                        touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                        Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                        RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
                        if (hitInformation.collider != null)
                        {
                            GameObject touchedObject = hitInformation.transform.gameObject;
                            return (touchedObject == gameObject);
                        }
                    }
                }
            }
        }
        return false;
    }

}
