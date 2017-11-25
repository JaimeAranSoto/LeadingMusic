using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_InfoArtistaSeleccionado : Singleton<UI_InfoArtistaSeleccionado>
{
    public Text textoGenero;
    public Text textoAccion;
    public Text textoSueldo;
    public Text textoDespedir;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("MostrarDatos", 0, 2);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Contratar()
    {
        DataManager.Instance.contratarArtista(DataManager.Instance.artistaActual);

        MostrarDatos(DataManager.Instance.artistaActual);

    }
    public void Despedir()
    {
        DataManager.Instance.artistaActual.contratado = false;
        MostrarDatos(DataManager.Instance.artistaActual);

    }
    public void MostrarDatos()
    {
        if (gameObject.activeInHierarchy)
            MostrarDatos(DataManager.Instance.artistaActual);
    }
    public void MostrarDatos(ArtistaData data)
    {
        Button contratar = textoDespedir.GetComponentInParent<Button>();

        textoGenero.text = data.genero.ToString();

        if (!data.contratado)
        {
            contratar.onClick.AddListener(Contratar);
            contratar.onClick.RemoveAllListeners();
            contratar.onClick.AddListener(Contratar);
            textoAccion.text = "No contratado";
            textoAccion.GetComponentInParent<Button>().interactable = false;
            textoDespedir.text = "Contratar";
        }
        else
        {
            contratar.onClick.AddListener(Despedir);
            contratar.onClick.RemoveAllListeners();
            contratar.onClick.AddListener(Despedir);
            textoDespedir.text = "Despedir";

            textoAccion.GetComponentInParent<Button>().interactable = true;

            textoAccion.text = "¡A rockear!";
            if (data.concierto.activo)
            {
                System.TimeSpan t = System.TimeSpan.FromSeconds(data.concierto.tiempo);
                textoAccion.text = "En concierto\n" + t.ToString();
                textoAccion.GetComponentInParent<Button>().interactable = false;
            }
        }
        textoSueldo.text = "Porcentaje de ganancia: <b>" + (data.porcentajeGanancias).ToString() + "%</b>";
    }
}
