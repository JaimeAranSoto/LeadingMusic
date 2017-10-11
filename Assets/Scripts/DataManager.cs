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
    public Concierto concierto;
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

public class DataManager : Singleton<DataManager>
{

    public int currentMoney;
    public List<Instrument> instruments;
    public List<ArtistaData> artists;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("timerVenta", 2, 1);

    }

    // Update is called once per frame
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
       foreach(InstrumentData inst in list)
       {

            if (getInstrument(inst.name) != null)
            {
                if(inst.level< getInstrument(inst.name).inst.level)
                {
                    return false;
                }
            }else
            {
                return false;
            }
        }
        if (list.Count > 0)
        {
            return true;
        }else
        {
            return false;
        }
    }
    public Instrument getInstrument(InstrumentData.InstrumentName instName)
    {
        for (int j = 0; j < instruments.Count; j++)
        {
            if (instruments[j].name.Equals(instName)){
                return instruments[j];
            }
        }
        return null;
    }

}
