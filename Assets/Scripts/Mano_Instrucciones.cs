using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mano_Instrucciones : Singleton<Mano_Instrucciones> {
 
	void Start () {
	
	}
	
	void Update () {
	
	}
    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
    public void SetPosition(Transform newPosition)
    {
        transform.parent = newPosition;
        GetComponent<RectTransform>().localPosition = new Vector3(160f, 0, 0);

       // GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
    public void setVisible(bool visible)
    {
        if (visible)
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        else
            GetComponent<Image>().color = new Color(1, 1, 1, 0);

    }

}