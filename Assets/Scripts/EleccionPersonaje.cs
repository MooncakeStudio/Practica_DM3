using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleccionPersonaje : MonoBehaviour
{
    public AudioSource src;
    public void CambiarEleccion(int eleccion)
    {
        switch (eleccion)
        {
            case 0:
                GameManager.eleccionPersonaje = Clase.LADRON;
                break;
            case 1:
                GameManager.eleccionPersonaje = Clase.MAGO;
                break;
            case 2:
                GameManager.eleccionPersonaje = Clase.GUERRERO;
                break;
        }
        
    }
}
