using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Concierto
{
    public int tiempo;
    public int ganancia;
    public bool activo;
    [XmlIgnore]
    public DateTime date;
    [XmlIgnore]
    public double newTime;
    [XmlIgnore]
    public bool recoger = false;
    // Use this for initialization
    void Start()
    {
        activo = false;
        tiempo = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool substractTiempo()
    {
        newTime = (DateTime.UtcNow - date).TotalSeconds;


        return (newTime < tiempo);
    }
    public void recogerDinero(ArtistaData artista)
    {
        if (recoger)
        {
            UI_SceneNavigator.Instance.chaching.Play();
            Debug.Log(DataManager.Instance.currentMoney + " + " + artista.concierto.ganancia + " = " + (DataManager.Instance.currentMoney + artista.concierto.ganancia));
            DataManager.Instance.currentMoney += artista.concierto.ganancia;

            PlayerPrefs.SetInt("Money", DataManager.Instance.currentMoney);
            recoger = false;
        }

    }
}
