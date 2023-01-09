using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleccionPersonaje : MonoBehaviour
{
    public void CambiarEleccion(int eleccion)
    {
        GameManager.eleccionPersonaje = (Clase)eleccion;
    }
}
