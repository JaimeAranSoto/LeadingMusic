using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmManager : Singleton<RythmManager>
{
    [Range(0,300)]
    public float BPM;
    [Range(0,100)]
    public int totalBeatCount;
    public AudioSource music;
    public AudioSource fx_win;
    public AudioSource fx_fail;
    public GameObject[] timeLines;
    private float lastTime, deltaTime, timer;
    private bool started;
    private double sampleTime;
    private double currentTime;
    public GameObject winText;
    private int currentBeat= 0;
    [HideInInspector]
    public float maxQuality;
   [HideInInspector]
    public float currentQuality;
    public void Initiate()
    {
        Start();
    }

    void Start()
    {
        started = false;
        currentTime = 0;
        sampleTime = (120f / BPM) * 44100;
        maxQuality = SceneNavigator.Instance.artista.talento;
        currentQuality = maxQuality * 0.6f;
        music.Play();
        Invoke("terminarCancion", music.clip.length + 1);
        currentBeat = 0;
    }

    void Update()
    {
        if (currentBeat < totalBeatCount)
        {
            currentQuality -= 0.05f;
        }
        if (currentQuality < 0)
        {
            currentQuality = 0;
        }
        if (currentQuality > maxQuality)
        {
            currentQuality = maxQuality;
        }

        if (music.isPlaying)
        {
            if (music.timeSamples > currentTime)
            {
                if (currentBeat <totalBeatCount)
                {
                    generateBeats();
                    currentTime += sampleTime;
                    currentBeat++;
                }

            }
        }

    }
    void generateBeats()
    {
        // Debug.Log((music.time - timePassed) * 120f);

        foreach (GameObject timeLine in timeLines)
        {
            timeLine.GetComponent<TimeLine>().Beat(sampleTime);
        }

    }

    void terminarCancion()
    {
        Disco disco = new Disco();
        disco.vendiendo = true;
        disco.tiempo = (int)(60f / SceneNavigator.Instance.artista.influencia);
        disco.ganancia = (1000 - (int)(1000 * (SceneNavigator.Instance.artista.porcentajeGanancias / 100f)) + (int)(1000 * currentQuality))/9;
        SceneNavigator.Instance.artista.disco = disco;
        winText.SetActive(true);
        winText.GetComponent<Text>().text = disco.ganancia.ToString();
        Invoke("metagame", 3);
        
    }
    void metagame()
    {
        winText.SetActive(false);
        SceneNavigator.Instance.GoToArtists();
    }
}
