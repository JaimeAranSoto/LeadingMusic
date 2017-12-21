using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Advertisements;
using TMPro;

public class InfoCiudad : Singleton<InfoCiudad>
{
    public Text texto;
    public Text nombre;
    public GameObject panelADS;
    public TMP_Text porcentaje_asistencia;
    public TMP_Text porcentaje_asistencia_aumentado;
    private Ciudad ciu;
    private int entrada;
    private int viaje;
    private float asistencia;
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
                if (Advertisement.IsReady())
                    panelADS.SetActive(true);
                float nueva = asistencia + (Math.Abs((1 - (Mathf.Log(asistencia * 100) / (asistencia * 50)) / 1.3f))) / 3.88768f;
                nueva = Mathf.Clamp01(nueva);
                porcentaje_asistencia_aumentado.SetText((int)(nueva * 100) + "%");

            }
            else
            {
                iniciarConcierto(asistencia);
            }
        }
    }

    public void aConciertoFijo()
    {
        iniciarConcierto(asistencia);
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
                float nuevaAsistencia = asistencia + (Math.Abs((1 - (Mathf.Log(asistencia * 100) / (asistencia * 50)) / 1.3f))) / 3.88768f;
                iniciarConcierto(Mathf.Clamp01(nuevaAsistencia));
                DataManager.Instance.conciertosRestantes = 5;

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                DataManager.Instance.conciertosRestantes = 5;
                iniciarConcierto(asistencia * 1.5f);

                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                iniciarConcierto(asistencia);

                break;
        }
    }

    public void iniciarConcierto(float asistenciaMinima)
    {
        asistenciaMinima = Mathf.Clamp(asistenciaMinima, 0.01f, 1);
        float asistenciaMaxima = Mathf.Clamp(asistenciaMinima * 1.24323f, asistenciaMinima, 1);
        DataManager.Instance.artistaActual.concierto.activo = true;
        DataManager.Instance.artistaActual.concierto.tiempo = viaje;
        DataManager.Instance.artistaActual.concierto.asistencia = UnityEngine.Random.Range(asistenciaMinima, asistenciaMaxima);
        DataManager.Instance.artistaActual.concierto.ganancia = (int)(entrada * ciu.capacidad * DataManager.Instance.artistaActual.concierto.asistencia);
        DataManager.Instance.artistaActual.concierto.date = DateTime.UtcNow;
        DataManager.Instance.conciertosRestantes--;
        PlayerPrefs.SetInt("ConciertosRestantes", DataManager.Instance.conciertosRestantes);
        UI_SceneNavigator.Instance.terminarConcierto();
        XMLManager.Serializar(DataManager.Instance.artistas, "artistas");
    }

    public void mostrarDatos(Ciudad ciudad, Color c)
    {
        ciu = ciudad;
        nombre.GetComponentInParent<Image>().color = c;
        nombre.text = ciudad.nombre;
        viaje = ciudad.distancia * 6;
        ArtistaData artista = DataManager.Instance.artistaActual;


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
        if (ciudad.generoFavorito == artista.genero)
        {
            entrada = (int)(entrada * 1.7634f);
        }

        asistencia = Mathf.Clamp(((artista.influencia / 50) / 1.113f) + Mathf.Log(ciudad.capacidad) / 15, 0, 1);
        if (ciudad.generoFavorito == artista.genero)
        {
            asistencia *= 1.3f;
            if (asistencia > 1)
            {
                asistencia = 0.93f;
            }
        }
   
        TimeSpan t = TimeSpan.FromSeconds(viaje);
        string duracion = t.ToString();
        texto.text = "Duracion: <b>" + duracion + "</b>\n" +
            "Capacidad: <b>" + ciudad.capacidad + "</b>\n" +
            "Entradas: <b>$" + entrada + "</b>\n" +
            "Género favorito: <b>" + ciudad.generoFavorito + "</b>";

        porcentaje_asistencia.SetText((int)(asistencia * 100) + "%");
    }
}