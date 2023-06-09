using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 offset = new Vector3(10, 0, 10);
    Personaje personaje = new Personaje();
    private PersonajeController objetivo;

    private bool EspecialCargado = true;

    private void Start()
    {
        personaje = new Guerrero();
        rb = GetComponent<Rigidbody>();
        objetivo = FindObjectOfType<PersonajeController>();
        var posicionPersonaje = objetivo.gameObject.transform.position;
        GetComponent<NavMeshAgent>().stoppingDistance = 2f;
        Vector2 pos = new Vector2(transform.position.x,transform.position.z);
        Vector2 posP = new Vector2(posicionPersonaje.x,posicionPersonaje.z);
        if(Vector2.Distance(pos,posP) > GetComponent<NavMeshAgent>().stoppingDistance){
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            agente.destination = posicionPersonaje;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        var posicionPersonaje = objetivo.gameObject.transform.position;
        Vector2 pos = new Vector2(transform.position.x, transform.position.z);
        Vector2 posP = new Vector2(posicionPersonaje.x, posicionPersonaje.z);
        if (Vector2.Distance(pos, posP) > GetComponent<NavMeshAgent>().stoppingDistance)
        {
            GetComponent<NavMeshAgent>().isStopped = false;
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            agente.destination = posicionPersonaje;
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);
            GetComponent<NavMeshAgent>().isStopped = true;
            
        }
        
        /*
        if(transform.position != posicionPersonaje + offset)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionPersonaje, Time.deltaTime * 15);
        }
        */

        if(personaje.GetVida() <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int d)
    {
        personaje.herida(d);
    }

    public int Getvida()
    {
        return personaje.GetVida();
    }

    public int Getataque()
    {
        return personaje.GetAtaque();
    }

    public void Atacar()
    {
        this.personaje.RealizarAtaque();
        GetComponent<Animator>().SetTrigger("Atacar");
    }

    public void AtaqueEspecial()
    {
        EspecialCargado = false;
        this.personaje.RealizarAtaqueEspecial();
        GetComponent<Animator>().SetTrigger("Especial");
    }

    private void OnDestroy()
    {
        GameManager.instance.EnemigoDerrotado();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EspecialMago"))
        {
            Debug.Log("Me atacan");
            personaje.herida(other.gameObject.GetComponentInParent<MagoController>().GetAtaque()*3/5);
        }else if (other.CompareTag("BasicoMago"))
        {
            Debug.Log("Me atacan");
            personaje.herida(other.gameObject.GetComponentInParent<AtaqueBasicoMagoDatos>().ataque);
        }
        else if (other.CompareTag("Espada"))
        {
            //Debug.Log(other.gameObject);
            personaje.herida(other.gameObject.GetComponentInParent<GuerreroController>().GetAtaque());
            Debug.Log("Me atacaron");
        }

        if (other.CompareTag("PersonajeObjetivo"))
        {
            Debug.Log("ataco");
            StartCoroutine(rutinaAtaque(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PersonajeObjetivo"))
        {
            StopCoroutine("rutinaAtaque");
        }
    }

    IEnumerator rutinaAtaque(GameObject other)
    {
        Debug.Log("Empezamos la rutina");
        if (EspecialCargado)
        {
            AtaqueEspecial();
            StartCoroutine(cooldownEspecial());
        }
        else
        {
            Atacar();
        }
        
        if (GameManager.eleccionPersonaje == Clase.LADRON)
        {
            other.GetComponentInParent<ArqueroController>().TakeDamage(this.Getataque());
        }
        else if (GameManager.eleccionPersonaje == Clase.MAGO)
        {
            other.GetComponentInParent<MagoController>().TakeDamage(this.Getataque());
        }
        else
        {
            other.GetComponentInParent<GuerreroController>().TakeDamage(this.Getataque());
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(rutinaAtaque(other));
    }

    IEnumerator cooldownEspecial()
    {
        yield return new WaitForSeconds(5);
        EspecialCargado = true;
    }

}
