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
    [SerializeField] private List<GameObject> spawnPoints;

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
        var ataque = Instantiate(basiquito);
        ataque.transform.position = spawnPoints[0].transform.position + transform.forward;
        ataque.transform.eulerAngles = new Vector3(90, transform.rotation.eulerAngles.y, 0);
        ataque.GetComponent<BolaMagica>().SetAtaque(personaje.GetAtaque());
        ataque.GetComponent<Rigidbody>().velocity = transform.forward*15;
        yield return new WaitForSeconds(0.01f);
    }

}
