using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClasificacionManager : MonoBehaviour
{
    // Atributos

    [SerializeField] private GameObject scrollClasificacion;

    [SerializeField] private List<Button> botones;


    // METODOS

    public void AbrirClasificacion()
    {
        foreach (var boton in botones)
        {
            boton.interactable = false;
        }

        scrollClasificacion.SetActive(true);
    }

    public void CerrarClasificacion()
    {
        foreach (var boton in botones)
        {
            boton.interactable = true;
        }

        scrollClasificacion.SetActive(false);
    }
}
