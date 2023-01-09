using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleccionPersonaje : MonoBehaviour
{
    public AudioSource src;
    public void CambiarEleccion(int eleccion)
    {
        GameManager.eleccionPersonaje = (Clase)eleccion;
    }
}
