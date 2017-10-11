using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contrato : MonoBehaviour
{
    private Button btn;
    private ArtistaData artist;
    private bool usable;
    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        artist = GetComponentInParent<Artista>().artista;
    }

    // Update is called once per frame
    void Update()
    {
        if (artist.contratado)
        {
            GetComponentInChildren<Text>().text = "Contratado";
            btn.interactable = false;
        }
        else
        {
            GetComponentInChildren<Text>().text = "Contratar";
        }
        //usable = false;

        if (DataManager.Instance.HasInstrumentLevel(artist.instruments))
        {
            if (!artist.contratado)
                btn.interactable = true;
        }

        else
        {
            btn.interactable = false;
            artist.contratado = false;
        }

    }
}
