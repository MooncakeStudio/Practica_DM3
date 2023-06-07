using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArqueroController : PersonajeController
{
    [Header("Prefab flecha")]
    [SerializeField] private GameObject basiquito;
    [SerializeField] private List<GameObject> spawnPoints;

    private void Awake()
    {
        personaje = new Arquero();

    }

    private void Start()
    {
        GetComponent<InputHandler>().changeToArquero();
    }
    new public void Atacar()
    {
        this.personaje.RealizarAtaque();
        GetComponent<Animator>().SetTrigger("Atacar");
        StartCoroutine(ataqueBasico());

    }

    new public void AtacarEspecial()
    {
        Debug.Log("Ataque mago");
        personaje.RealizarAtaqueEspecial();
        GetComponent<Animator>().SetTrigger("Especial");
        StartCoroutine(ataqueEspecial());

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
            ataque.GetComponent<FlechaArquero>().SetAtaque(personaje.GetAtaque());
            ataque.GetComponent<Rigidbody>().velocity = transform.forward * 15;
        }
        yield return new WaitForSeconds(0.01f);
    }
}
