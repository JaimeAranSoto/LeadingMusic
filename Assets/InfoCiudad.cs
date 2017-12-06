using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoCiudad : Singleton<InfoCiudad>
{
    public Text texto;
    public Text nombre;
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
            DataManager.Instance.artistaActual.concierto.activo = true;
            DataManager.Instance.artistaActual.concierto.tiempo = viaje;
            DataManager.Instance.artistaActual.concierto.ganancia = (int)(entrada * ciu.capacidad * Random.Range(0.5f, 1f));
            UI_SceneNavigator.Instance.terminarConcierto();
        }
    }
    public void mostrarDatos(Ciudad ciudad, Color c)
    {
        ciu = ciudad;
        nombre.GetComponentInParent<Image>().color = c;
        nombre.text = ciudad.nombre;
        viaje = ciudad.distancia * 6;

        if (ciudad.generoFavorito == DataManager.Instance.artistaActual.genero)
        {
            entrada = (int)(15 * ciudad.capacidad / Mathf.Log10(DataManager.Instance.artistaActual.influencia)) / 512;
        }
        else
        {
            if (ciudad.capacidad < 400)
            {
                entrada = (int)(4 * ciudad.capacidad / 5.3f) / 40;
            }else
            {
                entrada = (int)(4 * ciudad.capacidad / 5.3f) / 137;
            }
        }
        entrada /= 2;
        if (entrada < 2)
        {
            entrada = 2;
        }
        System.TimeSpan t = System.TimeSpan.FromSeconds(viaje);
        string duracion = t.ToString();
        texto.text = "Duracion: <b>" + duracion + "</b>\n" +
            "Capacidad: <b>" + ciudad.capacidad + "</b>\n" +
            "Entradas: <b>$" + entrada + "</b>\n" +
            "Género favorito: <b>" + ciudad.generoFavorito + "</b>";
    }
}