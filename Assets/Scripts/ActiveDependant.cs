using UnityEngine;
using System.Collections;
 
public class ActiveDependant : MonoBehaviour {
    public GameObject parent;
    private ParticleSystem part;
	void Start () {
        part = GetComponent<ParticleSystem>();
	}
	
	void Update () {
	    if(parent.activeInHierarchy && !part.isPlaying)
        {
            part.Play();
        }
        if(!parent.activeInHierarchy && part.isPlaying)
        {
            part.Stop();
        }
	}
}