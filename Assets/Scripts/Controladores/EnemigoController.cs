using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 offset = new Vector3(2, 0, 2);
    Personaje personaje = new Personaje();

    private void Start()
    {
        personaje = new Guerrero();
        rb = GetComponent<Rigidbody>();
        var posicionPersonaje = FindObjectOfType<PersonajeController>().gameObject.transform.position;
        if(transform.position != posicionPersonaje + offset){
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            agente.destination = posicionPersonaje;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        var posicionPersonaje = FindObjectOfType<PersonajeController>().gameObject.transform.position;
        if(transform.position != posicionPersonaje + offset){
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            agente.destination = posicionPersonaje;
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
        transform.Find("Personaje").GetComponent<Animator>().SetTrigger("Atacar");
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
            Atacar();
            if(GameManager.eleccionPersonaje==Clase.LADRON){
                other.gameObject.GetComponentInParent<PersonajeController>().TakeDamage(this.Getataque());
            } else if(GameManager.eleccionPersonaje==Clase.MAGO){
                other.gameObject.GetComponentInParent<MagoController>().TakeDamage(this.Getataque());
            }else{
                other.gameObject.GetComponentInParent<PersonajeController>().TakeDamage(this.Getataque());
            }
        }


    }
}
