using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour
{
    private Text t;
    public string[] lineas;

    public Button artistas;
    public Button shop;
    void Start()
    {
        t = GetComponentInChildren<Text>();
        t.text = lineas[DataManager.Instance.fase];
        if (DataManager.Instance.currentMoney >= DataManager.Instance.instruments[1].cost[1])
        {
            DataManager.Instance.fase = 3;
            action(2);
            action(DataManager.Instance.fase);
        }
    }

    void Update()
    {
        if (DataManager.Instance.fase >= 2)
        {
            artistas.interactable = true;
        }

    }
    public void setNext()
    {
        if (DataManager.Instance.fase < lineas.Length - 1)
        {
            if (DataManager.Instance.fase < 2 && !(DataManager.Instance.currentMoney >= DataManager.Instance.instruments[1].cost[1]))
            {
                DataManager.Instance.fase++;

                action(DataManager.Instance.fase);
            }

        }

    }


    private void action(int index)
    {
        t.text = lineas[index];
        switch (index)
        {
            case 2:
                artistas.interactable = true;
                break;
            case 3:
                shop.interactable = true;
                break;
        }
    }
}