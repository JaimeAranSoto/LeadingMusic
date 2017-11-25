using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampler : TimeLine
{
    public List<SamplerPad> pads;
    public int actualIndex;
    public int[] beatList;

    void Start()
    {
        pads = new List<SamplerPad>();
        foreach (Transform child in transform)
        {
            pads.Add(child.GetComponent<SamplerPad>());
        }
        actualIndex = 0;
  

    }

    void Update()
    {

    }
    public override void Stop()
    {
        foreach(SamplerPad pad in pads)
        {
            pad.Stop();
        }
    }
   

    public override void Beat(double sampleTime)
    {
        int beat = beatList[actualIndex];
        int next;
        if (actualIndex == beatList.Length - 1)
        {
            next = beatList[0];
        }
        else
        {
            next = beatList[actualIndex + 1];
        }
        pads[beat].Beat(sampleTime);
        pads[next].SetNext();
        actualIndex++;
        if (actualIndex > beatList.Length - 1)
        {
            actualIndex = 0;
        }



    }

}
