using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ResultadosCancion : MonoBehaviour
{
    public Text calidad;
    public Text popularidad;
    public Text total;
    private int n_total;
    void Start()
    {

    }

    void Update()
    {

    }
    public void OnEnable()
    {
        int n_calidad = RythmManager.Instance.ganancia;
        calidad.text = "$" + n_calidad.ToString();
        int n_popularidad = (int)(DataManager.Instance.artistaActual.influencia * n_calidad / Mathf.Clamp(Mathf.Log10(n_calidad + 1), 0.1f, 6));
        if (n_popularidad < 0)
            n_popularidad = 0;
        popularidad.text = "$" + n_popularidad;
        n_total = n_popularidad + n_calidad;
        total.text = "$" + n_total;
    }
    public void volver()
    {
        DataManager.Instance.currentMoney += n_total;
        SceneManager.LoadSceneAsync("Metagame");
        GetComponentInChildren<Button>().interactable = false;

    }
    public void concierto()
    {

    }
}