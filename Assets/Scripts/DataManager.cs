using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public int currentMoney;
    public List<InstrumentData> instruments;
    public List<ArtistaData> artistas;

    public List<Cancion> canciones;
    public Cancion cancionActual;
    public ArtistaData artistaActual; //indica cual es el indice de los datos del artista actual, así las acciones de artista sabe a cual se refiere;


    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        artistaActual = null;

        artistas = XMLManager.Deserializar<List<ArtistaData>>("artistas");

        canciones = XMLManager.Deserializar<List<Cancion>>("canciones");


        Invoke("manejarDatos", 0.2f);
        InvokeRepeating("timerVenta", 2, 1);
        InvokeRepeating("timerConcierto", 0, 1);
    }

    // Update is called once per frame
    public void UpgradeInstrumento(int index)
    {
        InstrumentData data = instruments[index];
        if (currentMoney > data.cost[data.level + 1] && data.level < data.cost.Length)
        {
            data.level++;
        }
    }

    public void contratarArtista(ArtistaData artista)
    {
        if (currentMoney >= artista.costoContrato)
        {
            currentMoney -= artista.costoContrato;
            artista.contratado = true;

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
            artista.concierto.substractTiempo(1);
        }
    }

    void timerVenta()
    {
        foreach (ArtistaData artista in artistas)
        {
            if (artista.disco != null)
                artista.disco.tiempo--;
            if (artista.concierto.activo)
            {
                artista.concierto.tiempo--;
            }
        }
    }

    void Update()
    {
        if (currentMoney < 0)
        {
            currentMoney = 0;
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
    }

}
