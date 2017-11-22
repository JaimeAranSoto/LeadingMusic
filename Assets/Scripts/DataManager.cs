using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public int currentMoney;
    public List<InstrumentData> instruments;
    public List<ArtistaData> artists;
    public TitleMenuData titleData;
    [HideInInspector]
    public List<InstrumentListData> instrumentReqList;
    public List<Cancion> canciones;

    public ArtistaData artistaActual; //indica cual es el indice de los datos del artista actual, así las acciones de artista sabe a cual se refiere;


    void Start()
    {
        artistaActual = null;
        DontDestroyOnLoad(gameObject);

        artists = XMLManager.Deserializar<List<ArtistaData>>("Assets/artistas.xml");
        instrumentReqList = XMLManager.Deserializar<List<InstrumentListData>>("Assets/instrumentRequirments.xml");
        //XMLManager.Serializar(canciones, "Assets/canciones.xml");

        Invoke("setRequerimientos", 0.2f);
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
    [SerializeField]
    public void UpgradeInstrumento(InstrumentData data)
    {
        if (data.level < data.cost.Length-1)
        {
            if (currentMoney > data.cost[data.level + 1] && data.level < data.cost.Length)
            {
                data.level++;
                currentMoney -= data.cost[data.level];
            }
        }
    }
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
