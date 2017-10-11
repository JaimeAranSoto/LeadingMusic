using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistRequirements : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
        ArtistaData artista = GetComponentInParent<Artista>().artista;
        if (!artista.contratado)
        {
            transform.localScale = new Vector2(1 + 0.2f * (float)Mathf.Sin((float)Time.time), 1 + 0.2f * (float)Mathf.Sin((float)Time.time));
            string instrumentsList = "";

            foreach (InstrumentData instrumento in artista.instruments)
            {
                instrumentsList += instrumento.name + " LVL (" + instrumento.level + ")\n";

            }
                string text = "Requiere:\n" + instrumentsList;
            GetComponent<Text>().text = text;
        } else
        {
            transform.localScale = new Vector2(1, 1);
            GetComponent<Text>().text = "¡Artista contratado!";
            GetComponent<Text>().color = new Color(146, 255, 0);
        }
       
    }
}
