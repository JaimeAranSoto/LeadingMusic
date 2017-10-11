using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistDescription : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int size = GetComponent<Text>().fontSize;
        ArtistaData artista = GetComponentInParent<Artista>().artista;
        
        string text = "<b>"+artista.nombre+"</b>" + "<size=" + size+">\nEstilo: "+artista.genero+"\nPorcentaje ganancias: " + artista.porcentajeGanancias + "%\nTalento: " +
            artista.talento + "%\nInfluencia: " + artista.influencia+ "</size>";
        GetComponent<Text>().text = text;
	}
}
