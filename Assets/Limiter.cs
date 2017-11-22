using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : TimeLine
{
    public GameObject prefabBarra;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Beat(double sampleTime)
    {
        GameObject barra = Instantiate(prefabBarra, transform, false);
        barra.transform.localPosition = new Vector3(2.13f, -1.3f, 0);
    }
}
