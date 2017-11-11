using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BarraArtista : MonoBehaviour
{
    public ArtistaData data;
    private Text text;
    private Scrollbar bar;
    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
        bar = GetComponentInChildren<Scrollbar>();
        text.text = data.nombre;
        bar.size = (float)data.talento / 100;
        GetComponent<Button>().onClick.AddListener(Click);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Click()
    {
        UI_InfoArtistaSeleccionado.Instance.MostrarDatos(data);
        DataManager.Instance.artistaActual = data;
    }


}
