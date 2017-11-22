using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccederCancion : MonoBehaviour {

    public Cancion cancion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Grabar()
    {
        UI_SceneNavigator.Instance.showMinigame();
    }
}
