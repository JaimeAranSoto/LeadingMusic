using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigator : Singleton<SceneNavigator> {
    public GameObject Minigame;
    public GameObject Shop;
    public GameObject Artists;
    public GameObject Metagame;
    public ArtistaData artista { get; set; }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Minigame.activeInHierarchy && artista==null)
        {
            GoToArtists();
        }
	}

    public void GoToMinigame(ArtistaData artista)
    {
        this.artista = artista;
        Shop.SetActive(false);
        Artists.SetActive(false);
        Minigame.SetActive(true);
        Metagame.SetActive(false);
        RythmManager.Instance.Initiate(); ;
    }
    public void GoToShop()
    {
        Shop.SetActive(true);
        Artists.SetActive(false);
        Minigame.SetActive(false);
        Metagame.SetActive(true);
    }
    public void GoToArtists()
    {
        Shop.SetActive(false);
        Artists.SetActive(true);
        Minigame.SetActive(false);
        Metagame.SetActive(true);
    }
}
