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

    public GameObject[] timeLines;

    private bool started;
    private double sampleTime;
    private double currentTime;

    private int currentBeat = 0;


    public float maxQuality=100;

    public float currentQuality=20;


    public void Initiate()
    {
        Start();
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
        GetComponent<AudioSource>().Play(44100);
        Invoke("terminarCancion", GetComponent<AudioSource>().clip.length + 1);
        crearTimelines();
        started = true;


    }
    void crearTimelines()
    {
        Instantiate(Resources.Load("Timelines/" + DataManager.Instance.cancionActual.tipo1), timeLines[0].transform);
        Instantiate(Resources.Load("Timelines/" + DataManager.Instance.cancionActual.tipo2), timeLines[1].transform);
    }
    void Update()
    {
        if (started)
        {
            if (currentBeat < totalBeatCount)
            {
                currentQuality -= 0.5f * Time.deltaTime;
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
        // Debug.Log((music.time - timePassed) * 120f);

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
        metagame();


    }
    void metagame()
    {
        int ganancia= (int)((currentQuality / maxQuality) * 3000);
       
        DataManager.Instance.currentMoney += ganancia;
        SceneManager.LoadScene("Metagame");
     

        //UI_SceneNavigator.Instance.showArtistas();
    }
    void OnEnable()
    {
        Start();
    }
}

