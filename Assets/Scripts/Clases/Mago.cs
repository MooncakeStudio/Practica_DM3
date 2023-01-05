using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : Personaje
{
    // CONSTRUCTOR

    public Mago(string nombre = "", int vida = 150, int ataque = 15, int defensa = 3) : base(nombre, vida, ataque, defensa) { }


    // METODOS

    override public void RealizarAtaque() 
    {
        Debug.Log("Mago: He realizado un ataque");
    }
    public override void RealizarAtaqueEspecial() 
    {
        Debug.Log("Mago: He realizado un ataque especial");
    }
}
