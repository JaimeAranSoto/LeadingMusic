using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Compra : MonoBehaviour
{
    [HideInInspector]
    public InstrumentData instrument;
    // Use this for initialization

    public void UpgradeInstrumento()
    {
        DataManager.Instance.UpgradeInstrumento(instrument);
        UI_SceneNavigator.Instance.animDinero();
    }
    public void Start()
    {
        transform.GetChild(1).GetComponent<Text>().text = instrument.name;
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = instrument.level.ToString();
        if (instrument.level < instrument.cost.Length-1)
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Mejorar $" + instrument.cost[instrument.level + 1].ToString();
        else
        {
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "MAX NIVEL";
        }
    }

    void Update()
    {
        if (instrument.level + 1 < instrument.cost.Length)
            GetComponentInChildren<Button>().interactable = (instrument.cost[instrument.level + 1] <= DataManager.Instance.currentMoney);
    }
}
