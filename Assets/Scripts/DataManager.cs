using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DataManager : Singleton<DataManager>
{

    public int currentMoney;
    public List<InstrumentData> instruments;
    public List<ArtistaData> artistas;
    public int conciertosRestantes = 1;
    public List<Cancion> canciones;
    public List<Ciudad> ciudades;
    public Cancion cancionActual;
    public ArtistaData artistaActual; //indica cual es el indice de los datos del artista actual, así las acciones de artista sabe a cual se refiere;
    [HideInInspector]
    public int fase = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("ConciertosRestantes"))
        {
            PlayerPrefs.SetInt("ConciertosRestantes", conciertosRestantes);
        }else
        {
            conciertosRestantes = PlayerPrefs.GetInt("ConciertosRestantes");
        }
        //DontDestroyOnLoad(gameObject);
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 500);
        }
        else
        {
            currentMoney = PlayerPrefs.GetInt("Money");
        }
        artistaActual = null;
        instruments = XMLManager.Deserializar<List<InstrumentData>>("listaInstrumentos");
        artistas = XMLManager.Deserializar<List<ArtistaData>>("artistas");

        canciones = XMLManager.Deserializar<List<Cancion>>("nuevasCanciones");

        ciudades = XMLManager.Deserializar<List<Ciudad>>("ciudades");

        Invoke("manejarDatos", 0.2f);
        InvokeRepeating("timerConcierto", 0, 1);
    }

    // Update is called once per frame
    public void UpgradeInstrumento(int index)
    {
        InstrumentData data = instruments[index];
        if (currentMoney > data.cost[data.level + 1] && data.level < data.cost.Length)
        {
            data.level++;
            XMLManager.Serializar(instruments, "Assets/Resources/listaInstrumentos.xml");

        }
    }

    public void contratarArtista(ArtistaData artista)
    {
        if (currentMoney >= artista.costoContrato)
        {
            currentMoney -= artista.costoContrato;
            PlayerPrefs.SetInt("Money", currentMoney);
            artista.contratado = true;
            XMLManager.Serializar(artistas, "Assets/Resources/artistas.xml");

        }

    }

    public void UpgradeInstrumento(InstrumentData data)
    {
        if (data.level < data.cost.Length - 1)
        {
            if (currentMoney > data.cost[data.level + 1] && data.level < data.cost.Length)
            {
                data.level++;
                currentMoney -= data.cost[data.level];
                PlayerPrefs.SetInt("Money", currentMoney);
            }
        }
    }



    void manejarDatos()
    {
        foreach (Cancion c in canciones)
        {
            c.setClip();
        }

    }
    void timerConcierto()
    {
        foreach (ArtistaData artista in artistas)
        {
            if (artista.concierto.activo)
            {
                if (!artista.concierto.substractTiempo())
                {
                    artista.concierto.recoger = true;
                    artista.concierto.activo = false;
                }
            }
        }
    }


    void Update()
    {
        if (currentMoney <= 0)
        {
            currentMoney = 300;
            PlayerPrefs.SetInt("Money", currentMoney);
        }
    }



    public InstrumentData getInstrument(InstrumentData.Timeline instName)
    {
        for (int j = 0; j < instruments.Count; j++)
        {
            if (instruments[j].name.Equals(instName))
            {
                return instruments[j];
            }
        }
        return null;
    }

    public void AddMoney(int newMoney)
    {
        this.currentMoney += newMoney;
        PlayerPrefs.SetInt("Money", currentMoney);
    }

}
