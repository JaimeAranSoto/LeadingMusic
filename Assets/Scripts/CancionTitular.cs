using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancionTitular : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = DataManager.Instance.artistaActual.nombre + "\r\n" + "<b>" + DataManager.Instance.cancionActual.name + "</b>";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
