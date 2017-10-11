using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quality : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = Vector2.Lerp(transform.localScale,new Vector2(RythmManager.Instance.currentQuality / 100, 1),4*Time.deltaTime);
	}
}
