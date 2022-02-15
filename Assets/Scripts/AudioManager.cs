using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sonidos;
    public AudioMixer audioMixer;
    public string audioMixerName;


    void Awake()
    {
        foreach (Sound s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.outputAudioMixerGroup = s.grupoSonido;

            s.source.PlayOneShot(s.sound, 1f);
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sonidos, sound => sound.name == name);
    }
    public void cambiarVolumen(float volumen)
    {
        audioMixer.SetFloat(audioMixerName, volumen);
        PlayerPrefs.SetFloat(audioMixerName, volumen);
    }
}
