using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabarButton : MonoBehaviour
{
    private ArtistaData artist;
    private Button btn;
    private Text text;
    // Use this for initialization
    void Start()
    {

        btn = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        artist = GetComponentInParent<Artista>().artista;
        btn.interactable = artist.contratado;
        if (artist.concierto.activo)
        {
            btn.interactable = false;
        }
        if (artist.disco != null)
        {
            if (artist.disco.tiempo > 0)
            {
                text.text = "Vendiendo disco (" + artist.disco.tiempo + "s)";
                btn.interactable = false;
            }
            else
            {
                text.text = "Grabar";
            }
        }
        else
        {
            text.text = "Grabar";
        }
    }
}
