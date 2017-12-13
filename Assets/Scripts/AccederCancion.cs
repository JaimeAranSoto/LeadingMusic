using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccederCancion : MonoBehaviour {

    public Cancion cancion;
    private Text t;
    public Transform dificultad;
    private GameObject icono;
	// Use this for initialization
	void Start () {
        t = GetComponentInChildren<Text>();
        icono = Resources.Load<GameObject>("Iconos/Dificultad");
        int dif = (int)(Mathf.Floor(((cancion.nivel1 + cancion.nivel2) / 2f)+0.00001f));
        for(int i = 0; i < dif; i++)
        {
            Instantiate(icono, dificultad);
        }

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
