using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sonidos;
    public AudioMixer audioMixer;
    private string master = "VolumenMaster";
    private string musica = "VolumenMusica";
    private string SFX = "VolumenSFX";

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
