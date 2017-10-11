using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrument : MonoBehaviour
{
    public InstrumentData inst;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inst.level == 0)
        {
            GetComponent<Image>().color = Color.blue;
        }else
        {
            GetComponent<Image>().color = Color.white;
        }
    }
    public void Upgrade()
    {
        if (inst.cost.Length > inst.level)
        {
            if (DataManager.Instance.currentMoney >= inst.cost[inst.level])
            {
                Debug.Log(DataManager.Instance.currentMoney + " >=" + inst.cost[inst.level + 1]);
                Debug.Log("De lvl " + inst.level + " a level " + (inst.level + 1) + " por $" + inst.cost[inst.level]);
                DataManager.Instance.currentMoney -= inst.cost[inst.level];
                inst.level += 1;
                
            }
        }
    }
    public void Downgrade()
    {
        if (inst.level > 0)
        {
            DataManager.Instance.currentMoney += inst.cost[inst.level -1];
            inst.level -= 1;
        }
    }
}
