using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NombreArtistasContrato : MonoBehaviour
{

    void Start()
    {
        GetComponent<Text>().text = DataManager.Instance.artistaActual.nombre;
    }

    void Update()
    {

    }
}