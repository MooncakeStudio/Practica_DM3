using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 offset = new Vector3(2, 0, 2);

    private void Start()
    {
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
    }

    private void OnDestroy()
    {
        GameManager.instance.EnemigoDerrotado();
    }
}
