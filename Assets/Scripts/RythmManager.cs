using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RythmManager : Singleton<RythmManager>
{
    [Range(0, 300)]
    public float BPM;
    [Range(0, 100)]
    public int totalBeatCount;
    public ResultadosCancion resultados;
    public GameObject[] timeLines;

    private bool started;
    private double sampleTime;
    private double currentTime;
    [HideInInspector]
    public int ganancia;
    private int currentBeat = 0;


    public float maxQuality = 100;

    public float currentQuality = 20;


    public void Initiate()
    {
        GetComponent<AudioSource>().Play(44100);
        Invoke("terminarCancion", GetComponent<AudioSource>().clip.length + 1);
        crearTimelines();
        started = true;
    }

    void Start()
    {
        BPM = DataManager.Instance.cancionActual.BPM;
        GetComponent<AudioSource>().clip = DataManager.Instance.cancionActual.clip;
        totalBeatCount = (int)(44100 / GetComponent<AudioSource>().clip.length) - 1;
        started = false;
        currentTime = 0;
        sampleTime = (120f / BPM) * 44100;

        currentBeat = 0;
        currentQuality = maxQuality * 0.5f;



    }
    void crearTimelines()
    {
       GameObject time1 =  Instantiate(Resources.Load("Timelines/" + DataManager.Instance.cancionActual.tipo1) as GameObject, timeLines[0].transform);
        time1.GetComponent<TimeLine>().nivel = DataManager.Instance.cancionActual.nivel1;
        GameObject time2 =  Instantiate(Resources.Load("Timelines/" + DataManager.Instance.cancionActual.tipo2) as GameObject, timeLines[1].transform);
        time2.GetComponent<TimeLine>().nivel = DataManager.Instance.cancionActual.nivel2;

    }
    void Update()
    {
        if (started)
        {
            if (currentBeat < totalBeatCount)
            {
                if (GetComponent<AudioSource>().isPlaying)
                    currentQuality -= 6f * Time.deltaTime;
            }
            if (currentQuality < 0)
            {
                currentQuality = 0;
            }
            if (currentQuality > maxQuality)
            {
                currentQuality = maxQuality;
            }

            if (GetComponent<AudioSource>().isPlaying)
            {
                if (GetComponent<AudioSource>().timeSamples > currentTime)
                {
                    if (currentBeat < totalBeatCount)
                    {
                        generateBeats();
                        currentTime += sampleTime;
                        currentBeat++;
                    }

                }
            }
        }
    }
    void generateBeats()
    {
       

        foreach (GameObject timeLine in timeLines)
        {
            timeLine.GetComponentInChildren<TimeLine>().Beat(sampleTime);
        }

    }

    void terminarCancion()
    {
        foreach (GameObject timeLine in timeLines)
        {
            timeLine.GetComponentInChildren<TimeLine>().Stop();

        }
        pantallaResultados();


    }
    void pantallaResultados()
    {
        ganancia = (int)((currentQuality / maxQuality) * 1500) - 100;


        resultados.gameObject.SetActive(true);


        //UI_SceneNavigator.Instance.showArtistas();
    }
    void OnEnable()
    {
        Start();
    }
}

