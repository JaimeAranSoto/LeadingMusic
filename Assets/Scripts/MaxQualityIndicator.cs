using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxQualityIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector2(RythmManager.Instance.maxQuality / 100f, 1);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
