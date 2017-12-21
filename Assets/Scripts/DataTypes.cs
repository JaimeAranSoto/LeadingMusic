using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization;


[Serializable]
public class ArtistaData
{

    public enum Genre { Rock, Metal, Latin, Pop, Country, Rap, Electro };


    public string nombre;
    public Genre genero;
    
    public bool contratado;
    [XmlIgnore]
    public Disco disco;
  
    public Concierto concierto = new Concierto();
    public int tiempoConcierto = 60;
    [Range(0, 100)]
    public int porcentajeGanancias;
    [Range(0, 100)]
    public int talento;
    [Range(1, 50)]
    public int influencia;
    [XmlIgnore]
    public int costoContrato = 200;

    public ArtistaData()
    { }
}
[Serializable]
public class Ciudad
{
    public int distancia;
    public string nombre;
    public ArtistaData.Genre generoFavorito;
    public int capacidad;
}
[Serializable]
public class InstrumentData
{
    public enum Timeline { Sampler, Limiter };
    public Timeline name;
    [SerializeField]
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
    public int BPM;

    [XmlEnum]
    public InstrumentData.Timeline tipo1;
    public int nivel1 = 1;
    [XmlEnum]
    public InstrumentData.Timeline tipo2;
    public int nivel2 = 1;

    public string clipPath = "Trackname";
    [XmlIgnore]
    public AudioClip clip;
    public ArtistaData.Genre genero;

    public Cancion()
    {

    }

    public void setClip()
    {
        clip = Resources.Load<AudioClip>("Audio/" + clipPath);
    }
}
class DataTypes
{
}

