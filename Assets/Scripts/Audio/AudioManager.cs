using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public Sound[] sonidos;
    public AudioMixer audioMixer;
    private string master = "VolumenMaster";
    private string musica = "VolumenMusica";
    private string SFX = "VolumenSFX";
    private float delayTime;
    private float NextPlay;


    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        foreach (Sound s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.outputAudioMixerGroup = s.grupoSonido;
            s.source.loop = s.enBucle;
            s.source.playOnAwake = false;
            if (s.playOnInit)
            {
                s.source.PlayOneShot(s.sound);

            }
            if (s.enBucle)
            {
                s.source.PlayScheduled(AudioSettings.dspTime + s.sound.length);
            }
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sonidos, sound => sound.name.Equals(name));
        s.source.PlayOneShot(s.sound);
    }
    public void playWithWaitTime(String name, float time1, float time2)
    {
        if (Time.time > NextPlay)
        {
            NextPlay = delayTime + Time.time;
            delayTime = UnityEngine.Random.Range(time1, time2);
            Sound s = Array.Find(sonidos, sound => sound.name.Equals(name));
            s.source.PlayOneShot(s.sound);
        }
    }
    public void cambiarVolumenMaster(float volumen)
    {
        audioMixer.SetFloat(master, volumen);
        PlayerPrefs.SetFloat(master, volumen);
    }
    public void cambiarVolumenMusica(float volumen)
    {
        audioMixer.SetFloat(musica, volumen);
        PlayerPrefs.SetFloat(musica, volumen);
    }
    public void cambiarVolumenSFX(float volumen)
    {
        audioMixer.SetFloat(SFX, volumen);
        PlayerPrefs.SetFloat(SFX, volumen);
    }
}
