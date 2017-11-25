using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccederCancion : MonoBehaviour {

    public Cancion cancion;
    private Text t;

	// Use this for initialization
	void Start () {
        t = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        t.text = cancion.name;
	}

  
    public void Seleccionar()
    {
        DataManager.Instance.cancionActual = cancion;
        UI_InfoCancion.Instance.mostrarActual();
    }
}
