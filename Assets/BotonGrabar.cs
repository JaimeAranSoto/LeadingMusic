using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotonGrabar : MonoBehaviour
{
    private Cancion c;
    private Button b;
    private Text t;
    void Start()
    {
   
        b = GetComponent<Button>();
        t = GetComponentInChildren<Text>();
    }

    void Update()
    {

        c = DataManager.Instance.cancionActual;
        if (DataManager.Instance.getInstrument(c.tipo1).level >= c.nivel1 && DataManager.Instance.getInstrument(c.tipo2).level >= c.nivel2)
        {
            b.interactable = true;
            t.text = "Grabar";
        }
        else
        {
            b.interactable = false;
            t.text = "Instrumentos requeridos";
        }

    }
}