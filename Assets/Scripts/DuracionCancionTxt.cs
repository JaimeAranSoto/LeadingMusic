using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DuracionCancionTxt : MonoBehaviour {
 
	void Start () {
        System.TimeSpan t = System.TimeSpan.FromSeconds((int)RythmManager.Instance.GetComponent<AudioSource>().clip.length);
        string duracion = t.ToString();
        GetComponent<Text>().text = "DURACION: <color=lime>" + duracion+"</color>";
	}
	
	void Update () {
	
	}
}