using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Artista : MonoBehaviour
{
  
    public ArtistaData artista;

    // Use this for initialization
    void Start()
    {
        artista = new ArtistaData();
        artista.concierto = new Concierto();
        artista.concierto.activo = false;
        artista.concierto.tiempo = 0;
        artista.concierto.ganancia = artista.influencia * (int)(300 * Mathf.Log10(artista.talento));

    }

    // Update is called once per frame
    void Update()
    {
        if (artista.disco != null)
        {
            if (artista.disco.tiempo <= 0 && artista.disco.vendiendo)
            {
                DataManager.Instance.currentMoney += artista.disco.ganancia;
                artista.disco.vendiendo = false;
                SceneNavigator.Instance.artista = null;
            }
        }
        if (artista.concierto.tiempo <= 0 && artista.concierto.activo)
        {
            DataManager.Instance.currentMoney += artista.concierto.ganancia;
            artista.concierto.activo = false;
        }
    }
    public void Contratar()
    {
        this.artista.contratado = true;
    }
    public void irAConcierto()
    {
        artista.concierto.activo = true;
        artista.concierto.tiempo = artista.tiempoConcierto;
    }
}
