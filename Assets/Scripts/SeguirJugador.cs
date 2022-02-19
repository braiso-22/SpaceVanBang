using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform player;
    public float speed = 1;
    private PlayerInputController playerInput;

    void Awake()
    {
        playerInput = new PlayerInputController();
    }

    void Update()
    {
        transform.position = player.position;
    }

}
