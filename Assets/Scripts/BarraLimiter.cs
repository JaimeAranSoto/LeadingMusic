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
        if (transform.localScale.x < 0)
        {
            RythmManager.Instance.currentQuality += 20;

            Destroy(gameObject);
        }
	}

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Limiter")
        {
            RythmManager.Instance.currentQuality -= 5 * transform.localScale.x;
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Linea")
        {
            transform.localScale -= new Vector3(0.7f*Time.deltaTime, 0, 0);
        }
    }
}
