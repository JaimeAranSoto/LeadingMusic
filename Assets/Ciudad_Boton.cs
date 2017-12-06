using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ciudad_Boton : MonoBehaviour
{
    public int indiceCiudad;
    private Ciudad ciudad;
    private Text texto;
    private Button boton;

    void Start()
    {
        ciudad = DataManager.Instance.ciudades[indiceCiudad];
        texto = GetComponentInChildren<Text>();
        boton = GetComponent<Button>();
        if (ciudad == null)
        {
            Debug.Log("Un botón de ciudad tiene un dato nulo!");
        }else
        {
            texto.text = ciudad.nombre;
        }
        boton.onClick.AddListener(mostrarDatos);

    }

    void Update()
    {

    }
    public void mostrarDatos()
    {
        InfoCiudad.Instance.mostrarDatos(ciudad,GetComponent<Image>().color);
    }
}