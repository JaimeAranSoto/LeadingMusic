using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SceneNavigator : MonoBehaviour
{
    public GameObject panelTitulo;
    public GameObject pantallaTitulo;
    public GameObject menuPrincipal;
    public GameObject artistas;
    public GameObject seleccionAccion;
    public GameObject minigameResultados;
    public GameObject grabar;
    public GameObject concierto;
    public GameObject ensayo;

    private List<GameObject> paneles;


    public GameObject prefabBarraArtistas;
    private Text titulo;

    // Use this for initialization
    void Start()
    {
        paneles = new List<GameObject>();
        paneles.Add(panelTitulo);
        paneles.Add(pantallaTitulo);
        paneles.Add(menuPrincipal);
        paneles.Add(artistas);
        paneles.Add(seleccionAccion);
        paneles.Add(minigameResultados);
        paneles.Add(grabar);
        paneles.Add(concierto);
        paneles.Add(ensayo);

        titulo = panelTitulo.GetComponentInChildren<Text>();
        showMenuPrincipal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showArtistas()
    {
        resetPaneles();
        titulo.text = "Artistas";
        panelTitulo.SetActive(true);
        artistas.SetActive(true);

        List<ArtistaData> list = DataManager.Instance.artists;
        //Eliminar barras actuales
        foreach (Transform child in artistas.GetComponentInChildren<GridLayoutGroup>().gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        //Crear barras y asignar datos
        for (int i = 0; i < list.Count; i++)
        {
            GameObject nuevo = Instantiate(prefabBarraArtistas, artistas.GetComponentInChildren<GridLayoutGroup>().gameObject.transform);
            nuevo.GetComponent<UI_BarraArtista>().data = list[i];
        }
    }
    public void showSeleccionAccion()
    {
        resetPaneles();
        panelTitulo.SetActive(true);
        seleccionAccion.SetActive(true);
        artistas.SetActive(true);
    }
    public void showMenuPrincipal()
    {
        resetPaneles();
        titulo.text = "Menu Principal";
        panelTitulo.SetActive(true);
        menuPrincipal.SetActive(true);
    }
    public void showGrabarRutina()
    {
        StartCoroutine(showGrabar());
    }
    public IEnumerator showGrabar()
    {
        yield return new WaitForSeconds(1);
        resetPaneles();
        panelTitulo.SetActive(true);
        grabar.SetActive(true);
        titulo.text = "Selecciona canción";
    }
    public void showMinigame()
    {
        resetPaneles();
        minigameResultados.SetActive(true);
       
    }
    public void resetPaneles()
    {
        foreach (GameObject panel in paneles)
        {
            panel.SetActive(false);
        }
    }
    public void showConcierto()
    {
        resetPaneles();
        panelTitulo.SetActive(true);
        titulo.text = "Elige ciudad";
        concierto.SetActive(true);
    }
    public void showEnsayo()
    {
        resetPaneles();
        panelTitulo.SetActive(true);
        ensayo.SetActive(true);
        titulo.text = "Elige tipo de ensayo";
        
    }
    public void terminarConcierto()
    {
        DataManager.Instance.artistaActual.concierto.activo = true;
        DataManager.Instance.artistaActual.concierto.tiempo = DataManager.Instance.artistaActual.tiempoConcierto;
        resetPaneles();
        showArtistas();
        UI_InfoArtistaSeleccionado.Instance.MostrarDatos(DataManager.Instance.artistaActual);
    }
}
