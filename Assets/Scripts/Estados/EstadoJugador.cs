using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EstadoJugador : MonoBehaviour
{
    // constructor
    protected EstadoJugador() { }
    static Flotando flotando;
    static EnGravedad enGravedad;

    // abstract manejaInput
    public abstract void manejarInput(PlayerController player, PlayerInputController input);
    // abstract actualizarEstado
    public abstract void actualizarEstado(PlayerController player);
}