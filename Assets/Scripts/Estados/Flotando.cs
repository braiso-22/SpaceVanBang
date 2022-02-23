using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotando : EstadoJugador
{
  // implementacion de metodos abstractos
    public override void manejarInput(PlayerController player, PlayerInputController input)
    {
        Debug.Log("Flotando");
    }

    public override void actualizarEstado(PlayerController player)
    {
        // no hace nada
    }
}
