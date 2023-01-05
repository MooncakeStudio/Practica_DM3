using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    Personaje personaje;

    public void Awake()
    {
        this.personaje = new Guerrero();    
    }

    public void Atacar()
    {
        this.personaje.RealizarAtaque();
    }

    public void AtacarEspecial()
    {
        this.personaje.RealizarAtaqueEspecial();
    }
}
