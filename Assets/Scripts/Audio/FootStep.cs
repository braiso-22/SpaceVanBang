using UnityEngine;
using UnityEngine.Audio;


public class FootStep : MonoBehaviour
{

    public AudioClip[] SonidoMetal;
    public AudioClip[] SonidoMadera;
    public AudioClip[] SonidoConcreto;
    public AudioClip[] SonidoTerreno;
    private float delayTime;
    private float NextPlay;

    void PlayFootStepSound()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f) & Time.time > NextPlay)
        {
            NextPlay = delayTime + Time.time;
            delayTime = Random.Range(0.25f, 0.5f);
            switch (hit.collider.tag)
            {
                case "metal":
                   // audio.clip = SonidoMetal[Random.Range(0, SonidoMetal.Length)];
                   // audio.Play();
                    break;
                case "madera":
                  //  audio.clip = SonidoMadera[Random.Range(0, SonidoMadera.Length)];
                   // audio.Play();
                    break;
                case "concreto":
                  //  audio.clip = SonidoConcreto[Random.Range(0, SonidoConcreto.Length)];
                   // audio.Play();
                    break;
                default:
                    //audio.clip = SonidoTerreno[Random.Range(0, SonidoTerreno.Length)];
                   // audio.Play();
                    break;
            }
        }
    }

    // Funcion start para inicializar el juego
    void Start()
    {
       // controller = GetComponent<CharacterController>();
    }

    // Funcion update para determinar frame por frame y mandar llamar objetos establecidos en el constructor
    void Update()
    {/*
        if (controller.isGrounded & controller.velocity.magnitude > 0.5)
        {
            PlayFootStepSound();
        }*/
    }
}
