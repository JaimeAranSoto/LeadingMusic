using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class AudioTrack
{
    public int id;
    public string name;
    public string url;
    public Boolean loop;
    public int loopCount;
    public int BPM;
    public AudioTrack()
    {

    }

}

public class SoundManager : MonoBehaviour

{
    [SerializeField]

    public AudioTrack[] audioTracks;

    // Use this for initialization
    void Start()
    {
        audioTracks = XMLManager.Deserializar<AudioTrack[]>("Assets/tracks.xml");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
