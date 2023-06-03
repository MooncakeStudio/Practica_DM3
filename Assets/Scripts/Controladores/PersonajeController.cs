using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    protected Personaje personaje;
    protected int tiempoRecarga;
    public void Awake()
    {
        personaje = new Arquero();
        /*if (personaje.GetType().Equals(typeof(Guerrero)))
        {
            animator.runtimeAnimatorController = listaAnimators[0];
        }else if (personaje.GetType().Equals(typeof(Mago)))
        {
            animator.runtimeAnimatorController = listaAnimators[1];
        }*/
    }

    public void Atacar()
    {
        this.personaje.RealizarAtaque();
    }

    public void AtacarEspecial()
    {
        this.personaje.RealizarAtaqueEspecial();
    }

    public int VidaTotal(){
        return this.personaje.GetVida();
    }

    public void SetPersonaje(Personaje personaje)
    {
        this.personaje = personaje;
    }

    public int GetTiempoRecarga() { return this.tiempoRecarga;}
    public void SetTiempoRecarga(int tiempoRecarga) { this.tiempoRecarga = tiempoRecarga; }
}
