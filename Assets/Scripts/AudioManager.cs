using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sonidos;
    public AudioSource reproductorAudio;

    public void playSound(int i)
    {
        if (i >= sonidos.Length)
        {
            Debug.Log("Ese sonido no está en la lista");
        }
        else
        {
            reproductorAudio.PlayOneShot(sonidos[i].sound);
        }
    }
}
