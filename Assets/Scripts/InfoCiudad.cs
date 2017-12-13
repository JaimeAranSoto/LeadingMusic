using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Advertisements;

public class InfoCiudad : Singleton<InfoCiudad>
{
    public Text texto;
    public Text nombre;
    public GameObject panelADS;
    private Ciudad ciu;
    private int entrada;
    private int viaje;
    void Start()
    {

    }

    void Update()
    {

    }
    public void aConcierto()
    {
        if (ciu != null)
        {
            if (DataManager.Instance.conciertosRestantes < 1)
            {
                panelADS.SetActive(true);
            }
            else
            {
                iniciarConcierto(0.5f);
            }
        }
    }
    public void mostrarAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }
    public IEnumerator ShowAdWhenReady()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show(null, options);
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                iniciarConcierto(0.95f);

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                iniciarConcierto(0.85f);

                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                iniciarConcierto(0.5f);

                break;
        }
    }

    public void iniciarConcierto(float asistenciaMinima)
    {
        DataManager.Instance.artistaActual.concierto.activo = true;
        DataManager.Instance.artistaActual.concierto.tiempo = viaje;
        DataManager.Instance.artistaActual.concierto.ganancia = (int)(entrada * ciu.capacidad * UnityEngine.Random.Range(asistenciaMinima, 1f));
        DataManager.Instance.artistaActual.concierto.date = DateTime.UtcNow;
        DataManager.Instance.conciertosRestantes--;
        PlayerPrefs.SetInt("ConciertosRestantes", DataManager.Instance.conciertosRestantes);
        UI_SceneNavigator.Instance.terminarConcierto();
    }

    public void mostrarDatos(Ciudad ciudad, Color c)
    {
        ciu = ciudad;
        nombre.GetComponentInParent<Image>().color = c;
        nombre.text = ciudad.nombre;
        viaje = ciudad.distancia * 6;



        if (ciudad.capacidad < 400)
        {
            entrada = (int)(4 * ciudad.capacidad / 5.3f) / 40;
        }
        else
        {
            entrada = (int)(4 * ciudad.capacidad / 5.3f) / 137;
        }

        entrada /= 2;
        if (entrada < 2)
        {
            entrada = 2;
        }
        if (ciudad.generoFavorito == DataManager.Instance.artistaActual.genero)
        {
            entrada = (int)(entrada * 1.7634f);
        }
        TimeSpan t = TimeSpan.FromSeconds(viaje);
        string duracion = t.ToString();
        texto.text = "Duracion: <b>" + duracion + "</b>\n" +
            "Capacidad: <b>" + ciudad.capacidad + "</b>\n" +
            "Entradas: <b>$" + entrada + "</b>\n" +
            "Género favorito: <b>" + ciudad.generoFavorito + "</b>";
    }
}