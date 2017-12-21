using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PropiedadArtista : MonoBehaviour
{
    public enum Propiedad { Talento, Popularidad }

    public Propiedad propiedad;
    private Text txt;

    void Awake()
    {
        txt = GetComponent<Text>();
        UI_SceneNavigator.Instance.mostrarEnsayo.AddListener(MostrarDatos);
    }

    void Update()
    {

    }
    public void MostrarDatos()
    {
        Debug.Log("mostrarDatos");
        ArtistaData data = DataManager.Instance.artistaActual;
        if (data != null)
        {
            if (propiedad == Propiedad.Popularidad)
            {
                txt.text = data.influencia.ToString();

            }
            if (propiedad == Propiedad.Talento)
            {
                txt.text = data.talento.ToString();
            }
        }
        else
        {
            data = DataManager.Instance.artistas[0];
            if (propiedad == Propiedad.Popularidad)
            {
                txt.text = data.influencia.ToString();

            }
            if (propiedad == Propiedad.Talento)
            {
                txt.text = data.talento.ToString();
            }
        }
    }




}