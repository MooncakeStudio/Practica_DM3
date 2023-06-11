using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMagica : MonoBehaviour
{
    private int ataque;

    public void SetAtaque(int ataque) { this.ataque = ataque; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<EnemigoController>().TakeDamage(ataque);
        }

        Destroy(gameObject);
    }
}
