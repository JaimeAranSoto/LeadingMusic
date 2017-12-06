using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Concierto
{
    public int tiempo;
    public int ganancia;
    public bool activo;
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
    public bool substractTiempo(int n)
    {
        if (activo)
        {
            tiempo -= n;

        }
        if (tiempo < 0)
        {
            activo = false;
        }
        return activo;
    }
}
