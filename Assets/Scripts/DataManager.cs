using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ArtistaData
{
    public enum Genre { Rock, Metal, Latin, Pop, Country, Rap };
    public string nombre;
    public Genre genero;
    public List<InstrumentData> instruments = new List<InstrumentData>();
    public bool contratado;
    public Disco disco;
    public Concierto concierto = new Concierto();
    public int tiempoConcierto = 60;
    [Range(0, 100)]
    public int porcentajeGanancias;
    [Range(0, 100)]
    public int talento;
    [Range(1, 5)]
    public int influencia;

    public ArtistaData()
    {

    }
}

[Serializable]
public class InstrumentData
{
    public enum InstrumentName { Guitar, Piano, Mixer, Microphone, Interface, Software, Brass, Drums };
    public InstrumentName name;
    public int level;
    public int[] cost = { 0, 1000, 2000, 2600, 3400 };

    public InstrumentData()
    {

    }
}

[Serializable]
public class TitleMenuData
{
    public string url;
    public Color backColor;
    public Color leadColor;
    public string description;
    public TitleMenuData()
    {

    }

}

public class DataManager : Singleton<DataManager>
{

    public int currentMoney;
    public List<Instrument> instruments;
    public List<ArtistaData> artists;
    public TitleMenuData titleData;
    public Camera cam;
    public ArtistaData artistaActual; //indica cual es el indice de los datos del artista actual, así las acciones de artista sabe a cual se refiere;
    // Use this for initialization
    void Start()
    {

        titleData = new TitleMenuData();
        titleData.url = "new.exe";
        titleData.description = "el mejor juego de la vida";
        titleData.leadColor = Color.white;
        titleData.backColor = Color.black;
        artistaActual = null;

        artists = XMLManager.Deserializar<List<ArtistaData>>("Assets/artistas.xml");

        //XMLManager.Serializar(artists, "Assets/artistas.xml");
        // titleData = XMLManager.Deserializar<TitleMenuData>("Assets/title.xml");
        //cam.backgroundColor = titleData.backColor;
        InvokeRepeating("timerVenta", 2, 1);
        InvokeRepeating("timerConcierto", 0, 1);

    }

    // Update is called once per frame

    void timerConcierto()
    {
        foreach (ArtistaData artista in artists)
        {
            artista.concierto.substractTiempo(1);
        }
    }
    void timerVenta()
    {
        foreach (ArtistaData artista in artists)
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

    public bool HasInstrumentLevel(List<InstrumentData> list)
    {
        foreach (InstrumentData inst in list)
        {

            if (getInstrument(inst.name) != null)
            {
                if (inst.level < getInstrument(inst.name).inst.level)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        if (list.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Instrument getInstrument(InstrumentData.InstrumentName instName)
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
