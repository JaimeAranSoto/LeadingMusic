using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InfoCancion : Singleton<UI_InfoCancion>
{
    Image icono1;
    Image icono2;
    Text bpm;
    Text duracion;
    // Use this for initialization
    void Start()
    {
        icono1 = transform.GetChild(2).GetComponent<Image>();
        icono2 = transform.GetChild(3).GetComponent<Image>();
        bpm = transform.GetChild(0).GetComponent<Text>();
        duracion = transform.GetChild(1).GetComponent<Text>();
        DataManager.Instance.cancionActual = DataManager.Instance.canciones[0];
        mostrarActual();
    }

    // Update is called once per frame
    void Update()
    {
        Cancion c = DataManager.Instance.cancionActual;

        GetComponentInChildren<Button>().interactable = (DataManager.Instance.getInstrument(c.tipo1).level >= c.nivel1 &&
            DataManager.Instance.getInstrument(c.tipo2).level >= c.nivel2);

    }

    public void mostrarActual()
    {
        Cancion c = DataManager.Instance.cancionActual;
        if (c.clip != null)
        {
            bpm.text = "BPM: <color=lime>" + c.BPM + "</color>";


            System.TimeSpan t = System.TimeSpan.FromSeconds((int)c.clip.length);

            duracion.text = t.Minutes.ToString("#00") + ":" + t.Seconds.ToString("#00") + "s";
            icono1.sprite = Resources.Load<Sprite>("Iconos/" + c.tipo1);

            icono2.sprite = Resources.Load<Sprite>("Iconos/" + c.tipo2);
            icono1.GetComponentInChildren<Text>().text = c.nivel1.ToString();
            icono2.GetComponentInChildren<Text>().text = c.nivel2.ToString();
        }

    }
    public void goToMinigame()
    {
        Cancion c = DataManager.Instance.cancionActual;

        if (DataManager.Instance.getInstrument(c.tipo1).level >= c.nivel1 && DataManager.Instance.getInstrument(c.tipo2).level >= c.nivel2)
        {
            UI_SceneNavigator.Instance.showMinigame();
        }
    }
}
