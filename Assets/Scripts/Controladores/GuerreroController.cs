using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuerreroController : PersonajeController
{
    [Header("Botones")]
    private Button botonBasico;
    private Button botonEspecial;

    private void Awake()
    {
        personaje = new Guerrero();
    }
    private void Start()
    {
        botonBasico = GetComponent<InputHandler>().ataque;
        botonEspecial = GetComponent<InputHandler>().habilidad;

        botonBasico.transform.Find("Baculo").gameObject.SetActive(false);
        botonBasico.transform.Find("Espada").gameObject.SetActive(true);

        botonEspecial.transform.Find("Baculo").gameObject.SetActive(false);
        botonEspecial.transform.Find("Espada").gameObject.SetActive(true);
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
