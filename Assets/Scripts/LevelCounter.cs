using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int level = GetComponentInParent<Instrument>().inst.level;
        if (level > 0)
        {
            GetComponent<Text>().text = "LVL " + level;
        }else
        {
            GetComponent<Text>().text = "You don't have a "+ GetComponentInParent<Instrument>().name;
        }
    }
}
