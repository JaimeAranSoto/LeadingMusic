using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BarraArtista : MonoBehaviour
{
    public ArtistaData data;
    private Text text;
  
    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
   
        text.text = data.nombre;
     
        GetComponent<Button>().onClick.AddListener(Click);
    }
    // Update is called once per frame
    void Update()
    {
        if (data.contratado)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);

        }
        if(data == DataManager.Instance.artistaActual)
        {
            text.color = Color.green;
        }else
        {
            text.color = Color.white;
        }
    }
    void Click()
    {
        UI_InfoArtistaSeleccionado.Instance.MostrarDatos(data);
        DataManager.Instance.artistaActual = data;
    }


}
