using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class DetalleConcierto : Singleton<DetalleConcierto>
{
    public Scrollbar asistencia;
    public Text ganancias;
    public TMP_Text porcentaje;

    void Start()
    {

    }

    void Update()
    {

    }
    void OnEnable()
    {
        ArtistaData artista = DataManager.Instance.artistaActual;
        asistencia.size = artista.concierto.asistencia;
        porcentaje.text = (int)(asistencia.size*100) + "%";
    }
}