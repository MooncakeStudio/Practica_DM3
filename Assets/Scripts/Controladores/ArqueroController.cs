using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArqueroController : PersonajeController
{
    [Header("Prefab flecha")]
    [SerializeField] private GameObject basiquito;
    [SerializeField] private List<GameObject> spawnPoints;
    [Header("Botones")]
    private Button botonBasico;
    private Button botonEspecial;

    private void Awake()
    {
        personaje = new Arquero();

    }

    private void Start()
    {
        GetComponent<InputHandler>().changeToArquero();
        botonBasico = GetComponent<InputHandler>().ataque;
        botonEspecial = GetComponent<InputHandler>().habilidad;

        botonBasico.transform.Find("Baculo").gameObject.SetActive(false);
        botonBasico.transform.Find("Arco").gameObject.SetActive(true);

        botonEspecial.transform.Find("Baculo").gameObject.SetActive(false);
        botonEspecial.transform.Find("Arco").gameObject.SetActive(true);
    }
    new public void Atacar()
    {      
        if (cdBasico){
            this.personaje.RealizarAtaque();
            GetComponent<Animator>().SetTrigger("Atacar");
            StartCoroutine(ataqueBasico());
            StartCoroutine(cooldownBasico());
        }

    }

    new public void AtacarEspecial()
    {
        if(cdEspecial){
            Debug.Log("Ataque arquero");
            personaje.RealizarAtaqueEspecial();
            GetComponent<Animator>().SetTrigger("Especial");
            StartCoroutine(ataqueEspecial());
            StartCoroutine(cooldownEspecial());
        }
    }

    public int GetAtaque() { return personaje.GetAtaque(); }

    IEnumerator ataqueBasico()
    {
        //Debug.Log("Entro en corutina");
        //var ataque = Instantiate(basiquito, transform.position + (transform.forward), transform.rotation);
        var ataque = Instantiate(basiquito);
        ataque.transform.position = spawnPoints[0].transform.position + transform.forward;
        ataque.transform.eulerAngles = new Vector3(90, transform.rotation.eulerAngles.y, 0);
        ataque.GetComponent<FlechaArquero>().SetAtaque(personaje.GetAtaque());
        ataque.GetComponent<Rigidbody>().velocity = transform.forward*15;
        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator ataqueEspecial()
    {
        for(var i = 0; i < 3; i++)
        {
            var ataque = Instantiate(basiquito);
            ataque.transform.position = spawnPoints[i].transform.position + (transform.forward);
            ataque.transform.eulerAngles = new Vector3(90, transform.rotation.eulerAngles.y, 0);
            ataque.GetComponent<FlechaArquero>().SetAtaque((int)Math.Ceiling(personaje.GetAtaque()*1.5));
            ataque.GetComponent<Rigidbody>().velocity = transform.forward * 15;
        }
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
        botonEspecial.GetComponent<Image>().color = new Color(0.4f,0.4f,0.4f,0.5f);
        yield return new WaitForSeconds(8);
        botonEspecial.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        cdEspecial = true;
    }
}
