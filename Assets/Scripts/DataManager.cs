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

    public List<InstrumentListData> instruments = new List<InstrumentListData>();
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
    { }
}

[Serializable]
public class InstrumentData
{
    //public enum String { Guitar, Piano, Mixer, Microphone, Interface, Software, Brass, Drums };
    public String name;
    public int level;
    
    public int[] cost = new int[5];


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
[Serializable]
public class InstrumentListData
{
    public int index;
    public string name;
    public int levelRequired;
}
public class DataManager : Singleton<DataManager>
{

    public int currentMoney;
    public List<InstrumentData> instruments;
    public List<ArtistaData> artists;
    public TitleMenuData titleData;
    [HideInInspector]
    public List<InstrumentListData> instrumentReqList;

    public ArtistaData artistaActual; //indica cual es el indice de los datos del artista actual, así las acciones de artista sabe a cual se refiere;
    // Use this for initialization
    void Start()
    {

               
        artistaActual = null;

        artists = XMLManager.Deserializar<List<ArtistaData>>("Assets/artistas.xml");
        instrumentReqList = XMLManager.Deserializar<List<InstrumentListData>>("Assets/instrumentRequirments.xml");
        XMLManager.Serializar(instruments, "Assets/instrumentos.xml");
        //XMLManager.Serializar(artists, "Assets/artistas.xml");
        //XMLManager.Serializar(instrumentReqList, "Assets/instrumentRequirments.xml");
                   
        Invoke("setRequerimientos", 0.2f);
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

    void setRequerimientos()
    {
        for (int i = 0; i < instrumentReqList.Count; i++)
        {
            if (artists[instrumentReqList[i].index] != null)
            {
                artists[instrumentReqList[i].index].instruments.Add(instrumentReqList[i]);
            }
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

    public bool HasInstrumentLevel(List<InstrumentListData> list)
    {
        foreach (InstrumentListData inst in list)
        {

            if (getInstrument(inst.name) != null)
            {
                if (inst.levelRequired < getInstrument(inst.name).level)
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
    public InstrumentData getInstrument(String instName)
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
