using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        int n_popularidad = (int)(DataManager.Instance.artistaActual.influencia * n_calidad / Mathf.Log10(n_calidad));
        popularidad.text = "$" + n_popularidad;
        n_total = n_popularidad + n_calidad;
        total.text = "$" + n_total;
    }
    public void volver()
    {
        DataManager.Instance.currentMoney += n_total;
        SceneManager.LoadSceneAsync("Metagame");
    }
    public void concierto()
    {

    }
}