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
    public AudioSource source;
    // Use this for initialization
    void Start()
    {

        audioTracks = XMLManager.Deserializar<AudioTrack[]>("Assets/tracks.xml");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public AudioClip getClip(int index)
    {
        AudioClip clip = Resources.Load<AudioClip>(audioTracks[index].url);
        return clip;
    }
    public AudioClip getClip(string name)
    {

        Debug.Log(getAudioTrack(name).url);
        AudioClip clip = Resources.Load(getAudioTrack(name).url) as AudioClip;

        if (clip == null)
        {
            Debug.Log("Audio Clip not found");
        }
        return clip;
    }
    public AudioTrack getAudioTrack(string name)
    {
        for (int i = 0; i < audioTracks.Length; i++)
        {
            if (audioTracks[i].name.Equals(name))
            {
                return audioTracks[i];
            }
        }
        return null;
    }
    public void playTrack(string name)
    {
        source.clip = getClip(name);
        source.loop = getAudioTrack(name).loop;
        source.Play();
    }
}
