using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_SceneNavigator : Singleton<UI_SceneNavigator>
{
    [Header("Titulo")]
    public GameObject panelTitulo;
    public GameObject pantallaTitulo;
    [Header("Menú principal")]
    public GameObject menuPrincipal;
    [Header("Panel artistas")]
    public GameObject artistas;
    public GameObject prefabBarraArtistas;
    [Header("Selección de accíón")]
    public GameObject seleccionAccion;
    [Header("Minigame")]
    public GameObject minigame;
    [Header("Panel grabación")]
    public GameObject grabar;
    public GameObject prefabCancion;
    [Header("Panel de concierto")]
    public GameObject concierto;
    [Header("Panel de ensayo")]
    public GameObject ensayo;
    [Header("Tienda")]
    public GameObject tienda;
    public GameObject prefabItem;

    private List<GameObject> paneles;



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
        paneles.Add(minigame);
        paneles.Add(grabar);
        paneles.Add(concierto);
        paneles.Add(ensayo);
        paneles.Add(tienda);

        titulo = panelTitulo.GetComponentInChildren<Text>();
        showMenuPrincipal();
    }

    // Update is called once per frame
    void Update()
    {
        panelTitulo.transform.GetChild(1).GetComponent<Text>().text = "$" + DataManager.Instance.currentMoney;
    }

    public void showArtistas()
    {
        resetPaneles();
        titulo.text = "Artistas";
        panelTitulo.SetActive(true);
        artistas.SetActive(true);

        List<ArtistaData> list = DataManager.Instance.artists;

        //Eliminar barras actuales
        foreach (Transform child in artistas.GetComponentInChildren<VerticalLayoutGroup>().gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //Crear barras y asignar datos
        for (int i = 0; i < list.Count; i++)
        {
            GameObject nuevo = Instantiate(prefabBarraArtistas, artistas.GetComponentInChildren<VerticalLayoutGroup>().gameObject.transform);
            nuevo.GetComponent<UI_BarraArtista>().data = list[i];
        }


        DataManager.Instance.artistaActual = list[0];
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
        yield return new WaitForSeconds(0.6f);
        resetPaneles();
        panelTitulo.SetActive(true);
        grabar.SetActive(true);
        titulo.text = "Selecciona canción";
        VerticalLayoutGroup g = grabar.GetComponentInChildren<VerticalLayoutGroup>();
        for (int i = 0; i < DataManager.Instance.canciones.Count; i++)
        {
            GameObject cancion = Instantiate(prefabCancion, g.transform);
            cancion.GetComponent<AccederCancion>().cancion = DataManager.Instance.canciones[i];
        }
    }

    /* public void showMinigame()
     {
         resetPaneles();
         minigame.SetActive(true);
     }
     public void showMinigame(Cancion cancion)
     {
         resetPaneles();
         minigame.GetComponent<AudioSource>().clip = cancion.clip;
         minigame.GetComponentInChildren<RythmManager>().BPM = cancion.BPM;
         minigame.SetActive(true);
     }*/

    public void showMinigame()
    {
        SceneManager.LoadScene("Minigame");
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
    public void showTienda()
    {
        resetPaneles();
        titulo.text = "Tienda";
        panelTitulo.SetActive(true);

        tienda.SetActive(true);
        Transform layout = tienda.transform.GetChild(0);
        for (int i = layout.childCount - 1; i >= 0; i--)
        {
            Destroy(layout.GetChild(i).gameObject);
        }
        for (int i = 0; i < DataManager.Instance.instruments.Count; i++)
        {
            GameObject item = Instantiate(prefabItem, layout);
            InstrumentData instrument = DataManager.Instance.instruments[i];
            item.GetComponent<Btn_Compra>().instrument = instrument;

        }
    }
    public void terminarConcierto()
    {
        DataManager.Instance.artistaActual.concierto.activo = true;
        DataManager.Instance.artistaActual.concierto.tiempo = DataManager.Instance.artistaActual.tiempoConcierto;
        resetPaneles();
        showArtistas();
        UI_InfoArtistaSeleccionado.Instance.MostrarDatos(DataManager.Instance.artistaActual);
    }
    public void goBack()
    {

        if (tienda.active)
        {
            showMenuPrincipal();
            return;
        }
        if (artistas.active)
        {
            showMenuPrincipal();
            return;
        }
        if (ensayo.active)
        {
            showArtistas();
            return;
        }
        if (concierto.active)
        {
            showArtistas();
            return;
        }
        if (minigame.active)
        {
            showArtistas();
            return;
        }

    }
    public void animDinero()
    {
        panelTitulo.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Cambio");
    }
}
