using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraLimiter : MonoBehaviour {
    public float speed = 2.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
	}

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Limiter")
        {
            Destroy(gameObject);
        }
    }
}
