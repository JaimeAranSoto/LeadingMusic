using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
[Serializable]
public class Cancion
{
    public string name;
    public int indexArtista;
    public int instrumento1;
    public int instrumento2;
    public AudioClip clip;
    public int BPM;
    public Cancion()
    {

    }
}
class DataTypes
{
}

