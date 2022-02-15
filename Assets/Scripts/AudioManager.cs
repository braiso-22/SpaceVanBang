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
        existeVolumen();

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
    private void existeVolumen()
    {
        if (PlayerPrefs.GetInt("master") == 1)
        {
            return;
        }
        PlayerPrefs.SetInt("master", 0);
        audioMixer.SetFloat(audioMixerName, -32f);

    }
}
