using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arquero : Personaje
{
    // CONSTRUCTOR

    Arquero(string nombre = "", int vida = 150, int ataque = 15, int defensa = 3) : base(nombre, vida, ataque, defensa) { }


    // METODOS

    override public void RealizarAtaque()
    {
        Debug.Log("He realizado un ataque");
    }
    public override void RealizarAtaqueEspecial()
    {
        Debug.Log("He realizado un ataque especial");
    }
}
