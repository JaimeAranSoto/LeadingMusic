using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }
    public void SetText()
    {
        GetComponent<Text>().text = "$"+DataManager.Instance.currentMoney.ToString();
    }
}