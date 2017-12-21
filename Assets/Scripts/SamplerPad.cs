using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplerPad : TimeLine
{
    private Animator anim;
    public bool isNext;
    Vector3 touchPosWorld;


    void Start()
    {
        anim = GetComponent<Animator>();
        isNext = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (checkInput())
        {
            anim.SetTrigger("Pulsado");
            RythmManager.Instance.currentQuality += 8;
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
        if (nivel == 1)
        {
            anim.speed = 1;
        }
        else if (nivel == 2)
        {
            anim.speed = 1.7f;
        }
        else if (nivel == 3)
        {
            anim.speed = 2.5f;
        }

        if (isNext)
        {
            anim.SetTrigger("Beat");
            isNext = false;
        }
    }
    public void SetNext()
    {
        isNext = true;
        anim.SetBool("TieneSample", true);
    }
    public void Perder()
    {
        RythmManager.Instance.currentQuality -= 6;
        Instantiate(Resources.Load("Timelines/Pad Error"), transform);
    }

    bool checkInput()
    {
        if (Input.touchCount < 1)
        {
            return false;
        }
        Collider2D col = GetComponent<Collider2D>();
        if (col.isActiveAndEnabled)
        {
            foreach (Touch touch in Input.touches)
            {
                if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
                {
                    if (touch.phase == TouchPhase.Began)
                        return true;
                }
            }
        }
        return false;
        /* if (Input.touchCount > 0)
         {
             {
                 for (int i = 0; i < Input.touchCount; i++)
                 {
                     if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
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
         return false;*/
    }

}
