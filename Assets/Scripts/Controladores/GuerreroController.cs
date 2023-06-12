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
        if (cdBasico)
        {
            this.personaje.RealizarAtaque();
            GetComponent<Animator>().SetTrigger("Atacar");
            StartCoroutine(cooldownBasico());
        }
    }

    public void Habilidad()
    {
        if (cdEspecial)
        {
            Debug.Log("Ataque mago");
            personaje.RealizarAtaqueEspecial();

            GetComponent<Animator>().SetTrigger("Especial");
            StartCoroutine(cooldownEspecial());
        }
    }

    public int GetAtaque()
    {
        return personaje.GetAtaque();
    }

    IEnumerator cooldownBasico()
    {
        cdBasico = false;
        botonBasico.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
        yield return new WaitForSeconds(1);
        botonBasico.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        cdBasico = true;
    }

    IEnumerator cooldownEspecial()
    {
        cdEspecial = false;
        botonEspecial.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
        yield return new WaitForSeconds(7);
        botonEspecial.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        cdEspecial = true;
    }
}
