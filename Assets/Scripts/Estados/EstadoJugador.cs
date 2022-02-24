using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EstadoJugador : MonoBehaviour
{
    protected static Flotando flotando;
    protected static EnGravedad enGravedad;
    // constructor
    protected EstadoJugador() { }

    // abstract manejaInput
    public abstract void manejarInput(PlayerController player, PlayerInputController input);
    // abstract actualizarEstado
    public abstract void actualizarEstado(PlayerController player);
}