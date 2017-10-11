using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConciertoBtn : MonoBehaviour
{
    private ArtistaData artist;
    private Button btn;
    private Text text;
    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        artist = GetComponentInParent<Artista>().artista;
    }

    // Update is called once per frame
    void Update()
    {
        if (artist.contratado)
        {
            if (!artist.concierto.activo)
            {
                btn.interactable = true;
                text.text = text.text = "Concierto";
            }
            else
            {
                btn.interactable = false;
                text.text = text.text = "Concierto (" + artist.concierto.tiempo + "s)";
            }
        }else
        {
            btn.interactable = false;
        }
    }
}
