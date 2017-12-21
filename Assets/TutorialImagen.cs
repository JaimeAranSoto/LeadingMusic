using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialImagen : MonoBehaviour
{
    public InstrumentData.Timeline timeline;
    public string key;
    public Animator datos;
    void Start()
    {
        datos.speed = 1;

        if (PlayerPrefs.HasKey(key))
        {
            if (PlayerPrefs.GetInt(key) == 1)
            {
                gameObject.SetActive(false);
                datos.speed = 1;
            }

        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
        if (!(DataManager.Instance.cancionActual.tipo1 == timeline || DataManager.Instance.cancionActual.tipo2 == timeline))
        {
            gameObject.SetActive(false);

        }
        else
        {
            if (isActiveAndEnabled)
                datos.speed = 0;

        }
    }

    void Update()
    {

    }
    public void Presionar()
    {
        Debug.Log(name);
        PlayerPrefs.SetInt(key, 1);
        datos.speed = 1;

        gameObject.SetActive(false);

    }
}