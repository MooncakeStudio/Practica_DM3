using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Guerrero : Personaje
{
    // CONSTRUCTOR

    public Guerrero(string nombre = "", int vida = 150, int ataque = 15, int defensa = 3) : base(nombre, vida, ataque, defensa) { }


    // METODOS

    override public void RealizarAtaque()
    {
        Debug.Log("Guerrero: He realizado un ataque");

        // Activar animacion
    }
    public override void RealizarAtaqueEspecial()
    {
        Debug.Log("Guerrero: He realizado un ataque especial");
    }
}
