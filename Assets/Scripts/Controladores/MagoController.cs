using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagoController : PersonajeController
{

    [Header("Prefab fueguito")]
    [SerializeField] private SphereCollider fueguito;
    [SerializeField] private ParticleSystem fuego;
    [SerializeField] private ParticleSystem humo;
    [Header("Prefab basico")]
    [SerializeField] private GameObject basiquito;
    [SerializeField] private List<GameObject> spawnPoints;
    [Header("CD")]
    [SerializeField] private bool cdBasico = true;
    [SerializeField] private bool cdEspecial = true;
    [Header("Botones")]
    private Button botonBasico;
    private Button botonEspecial;

    private void Awake()
    {
        personaje = new Mago();
       
    }

    private void Start()
    {
        GetComponent<InputHandler>().changeCallback();

        botonBasico = GetComponent<InputHandler>().ataque;
        botonEspecial = GetComponent<InputHandler>().habilidad;

    }
    public void Atacar()
    {
        if(cdBasico){
            this.personaje.RealizarAtaque();
            GetComponent<Animator>().SetTrigger("Atacar");
            StartCoroutine(ataqueBasico());
            StartCoroutine(cooldownBasico());
        }

    }

    new public void AtacarEspecial() 
    {
        if(cdEspecial){
            Debug.Log("Ataque mago");
            personaje.RealizarAtaqueEspecial();
            fueguito.enabled= true;
            fuego.Play();
            humo.Play();
            GetComponent<Animator>().SetTrigger("Especial");
            StartCoroutine(cooldownEspecial());
        }
        
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

    IEnumerator cooldownBasico(){
        cdBasico = false;
        botonBasico.GetComponent<Image>().color = new Color(0.4f,0.4f,0.4f,0.5f);
        yield return new WaitForSeconds(1);
        botonBasico.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        cdBasico = true;
    }

    IEnumerator cooldownEspecial(){
        cdEspecial = false;
        botonBasico.GetComponent<Image>().color = new Color(0.4f,0.4f,0.4f,0.5f);
        yield return new WaitForSeconds(7);
        botonBasico.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        cdEspecial = true;
    }

}
