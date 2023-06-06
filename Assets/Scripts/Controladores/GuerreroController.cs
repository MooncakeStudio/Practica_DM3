using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerreroController : PersonajeController
{
    private void Awake()
    {
        personaje = new Guerrero();
    }

    public void Atacar()
    {
        this.personaje.RealizarAtaque();
        GetComponent<Animator>().SetTrigger("Atacar");
    }

    new public void AtacarEspecial()
    {
        Debug.Log("Ataque mago");
        personaje.RealizarAtaqueEspecial();

        GetComponent<Animator>().SetTrigger("Especial");
    }

    public int GetAtaque() { return personaje.GetAtaque(); }
}
