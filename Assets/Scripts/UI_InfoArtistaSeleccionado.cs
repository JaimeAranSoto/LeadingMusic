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
    public Transform mainUI;
    public Text extras;
    public GameObject detalles;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("MostrarDatos", 0, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Contratar()
    {
        DataManager.Instance.contratarArtista(DataManager.Instance.artistaActual);
        Instantiate(Resources.Load<GameObject>("Contrato"), mainUI);
        MostrarDatos(DataManager.Instance.artistaActual);

    }
    public void Despedir()
    {
        DataManager.Instance.artistaActual.contratado = false;
        DataManager.Instance.currentMoney += DataManager.Instance.artistaActual.costoContrato;
        MostrarDatos(DataManager.Instance.artistaActual);

    }
    public void MostrarDatos()
    {
        if (gameObject.activeInHierarchy)
            MostrarDatos(DataManager.Instance.artistaActual);
    }
    public void MostrarDatos(ArtistaData data)
    {
        extras.text = "Talento: " + data.talento + "\nPopularidad: " + data.influencia;
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
            contratar.image.color = Color.green;
        }
        else
        {
            contratar.onClick.AddListener(Despedir);
            contratar.onClick.RemoveAllListeners();
            contratar.onClick.AddListener(Despedir);
            contratar.image.color = Color.red;
            textoDespedir.text = "Despedir";

            textoAccion.GetComponentInParent<Button>().interactable = true;

            textoAccion.text = "¡A rockear!";
            if (data.concierto.activo)
            {
                System.TimeSpan t = System.TimeSpan.FromSeconds(data.concierto.tiempo - (int)data.concierto.newTime);
                textoAccion.text = "En concierto\n" + t.Minutes.ToString("#00") + ":" + t.Seconds.ToString("#00");
                textoAccion.GetComponentInParent<Button>().interactable = false;
            }
        }
        if (data.concierto.recoger)
        {
            textoAccion.text = ("Recoger ganancia\n$" + data.concierto.ganancia);
            textoAccion.GetComponentInParent<Button>().onClick.AddListener(mostrarDetalles);
            textoAccion.GetComponentInParent<Button>().onClick.AddListener(data.concierto.recogerDinero);
            textoAccion.GetComponentInParent<Button>().onClick.RemoveListener(UI_SceneNavigator.Instance.showSeleccionAccion);
            textoAccion.GetComponentInParent<Button>().image.color = Color.magenta;
            textoAccion.color = Color.white;

        }
        else
        {
            textoAccion.GetComponentInParent<Button>().onClick.AddListener(UI_SceneNavigator.Instance.showSeleccionAccion);
            textoAccion.GetComponentInParent<Button>().onClick.RemoveListener(data.concierto.recogerDinero);
            textoAccion.GetComponentInParent<Button>().onClick.RemoveListener(mostrarDetalles);
            textoAccion.color = Color.black;
            textoAccion.GetComponentInParent<Button>().image.color = Color.white;

        }
        textoSueldo.text = "Porcentaje de ganancia: <b>" + (data.porcentajeGanancias).ToString() + "%</b>";
    }
    public void mostrarDetalles()
    {
        detalles.SetActive(true);
    }
}
