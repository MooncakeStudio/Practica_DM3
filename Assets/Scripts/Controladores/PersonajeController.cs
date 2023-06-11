using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    protected Personaje personaje;
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

    public void TakeDamage(int d)
    {
        personaje.herida(d);
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
}
