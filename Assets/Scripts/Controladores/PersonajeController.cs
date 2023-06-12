using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    protected Personaje personaje;

    [Header("CD")]
    [SerializeField] protected bool cdBasico = true;
    [SerializeField] protected bool cdEspecial = true;

    public delegate void MuertoEvent();
    public static event MuertoEvent Muerto;
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
        Debug.Log("Personaje recibe da�o");
        personaje.herida(d);
        GetComponent<VidaController>().actualizarVida(personaje.GetVida());
        if (personaje.GetVida() <= 0)
        {
            Muerto?.Invoke();
        }
    }
    public void Atacar()
    {
        this.personaje.RealizarAtaque();
    }

    public void AtacarEspecial()
    {
        this.personaje.RealizarAtaqueEspecial();
    }

    public int VidaTotal()
    {
        return this.personaje.GetVida();
    }

    public void SetPersonaje(Personaje personaje)
    {
        this.personaje = personaje;
    }
}