using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditosManager : MonoBehaviour
{
    // Atributos

    [SerializeField] private GameObject panelCreditos;

    [SerializeField] private List<Button> botones;


    // METODOS

    public void AbrirCreditos()
    {
        foreach (var boton in botones)
        {
            boton.interactable = false;
        }

        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        foreach (var boton in botones)
        {
            boton.interactable = true;
        }

        panelCreditos.SetActive(false);
    }
}
