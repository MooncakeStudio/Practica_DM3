using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoController : PersonajeController
{

    [Header("Prefab fueguito")]
    [SerializeField] private SphereCollider fueguito;

    private void Awake()
    {
        personaje = new Mago();
       
    }

    private void Start()
    {
        GetComponent<InputHandler>().changeCallback();
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
        fueguito.enabled= true;

        GetComponent<Animator>().SetTrigger("Especial");
    }

    public int GetAtaque() { return personaje.GetAtaque(); }

    public void FinAtacarEspecial()
    {
        fueguito.enabled = false;
    }
}
