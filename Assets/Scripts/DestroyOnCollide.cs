using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour {
    public float qualityLoose;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        RythmManager.Instance.currentQuality -= qualityLoose;

        Destroy(col.gameObject);
    }
}
