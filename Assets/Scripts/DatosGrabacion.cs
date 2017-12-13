using UnityEngine;
using System.Collections;
 
public class DatosGrabacion : MonoBehaviour {
    private AudioClip clip;
	void Start () {
        clip = DataManager.Instance.cancionActual.clip;

    }
	
	void Update () {
	
	}
    void Comenzar()
    {
        RythmManager.Instance.Initiate();
    }
}