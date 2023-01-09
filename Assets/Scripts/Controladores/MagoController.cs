using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoController : PersonajeController
{

    [Header("Prefab fueguito")]
    [SerializeField] private SphereCollider fueguito;
    [SerializeField] private ParticleSystem fuego;
    [SerializeField] private ParticleSystem humo;
    [Header("Prefab basico")]
    [SerializeField] private GameObject basiquito;

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
        StartCoroutine(ataqueBasico());

    }

    new public void AtacarEspecial() 
    {
        Debug.Log("Ataque mago");
        personaje.RealizarAtaqueEspecial();
        fueguito.enabled= true;
        fuego.Play();
        humo.Play();
        GetComponent<Animator>().SetTrigger("Especial");
    }

    public int GetAtaque() { return personaje.GetAtaque(); }

    public void FinAtacarEspecial()
    {
        fuego.Stop();
        humo.Stop();
        fueguito.enabled = false;
    }

    IEnumerator ataqueBasico()
    {
        var ataque = Instantiate(basiquito, transform.position + (transform.forward * 15), transform.rotation);
        ataque.GetComponent<AtaqueBasicoMagoDatos>().ataque = personaje.GetAtaque();
        yield return new WaitForSeconds(0.5f);
        Destroy(ataque);
    }
}
