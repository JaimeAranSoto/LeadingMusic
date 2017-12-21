using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Concierto
{
    public float asistencia;
    public int tiempo;
    public int ganancia;
    public bool activo;
    [SerializeField]
    public DateTime date;

    public double newTime;

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
    public void recogerDinero()
    {
        if (recoger)
        {
            UI_SceneNavigator.Instance.chaching.Play();
            
            DataManager.Instance.currentMoney += ganancia;

            PlayerPrefs.SetInt("Money", DataManager.Instance.currentMoney);
            recoger = false;
            XMLManager.Serializar(DataManager.Instance.artistas, "artistas");
            return;
        }

    }
}
