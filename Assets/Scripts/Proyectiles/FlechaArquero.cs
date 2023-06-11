using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaArquero : MonoBehaviour
{

    private int ataque;

    public void SetAtaque(int ataque) { this.ataque = ataque; }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<EnemigoController>().TakeDamage(ataque);
        }

        Destroy(gameObject);
    }
}
