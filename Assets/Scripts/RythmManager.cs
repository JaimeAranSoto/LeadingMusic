using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmManager : Singleton<RythmManager>
{
    [Range(0, 300)]
    public float BPM;
    [Range(0, 100)]
    public int totalBeatCount;

    public AudioSource music;
    public AudioSource fx_win;
    public AudioSource fx_fail;

    public TimeLine[] timeLines;

    private bool started;
    private double sampleTime;
    private double currentTime;

    private int currentBeat = 0;

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
        maxQuality = 45;
        currentQuality = maxQuality * 0.6f;
        music.Play();
        Invoke("terminarCancion", music.clip.length + 1);
        currentBeat = 0;

    }

    void Update()
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

        if (music.isPlaying)
        {
            if (music.timeSamples > currentTime)
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
    void generateBeats()
    {
        // Debug.Log((music.time - timePassed) * 120f);

        foreach (TimeLine timeLine in timeLines)
        {
            timeLine.Beat(sampleTime);
        }

    }

    void terminarCancion()
    {
        foreach (TimeLine timeLine in timeLines)
        {
            timeLine.Stop();
        }
        metagame();


    }
    void metagame()
    {

        UI_SceneNavigator.Instance.showArtistas();
    }
    void OnEnable()
    {
        Start();
    }
}

