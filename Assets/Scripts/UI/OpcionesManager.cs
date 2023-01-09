using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesManager : MonoBehaviour
{
    [SerializeField] GameObject menuOpciones;

    [SerializeField] List<Button> botones;

    public void AbreOpciones()
    {
        foreach (var boton in botones)
        {
            boton.interactable = false;
        }

        menuOpciones.SetActive(true);
    }

    public void CierraOpciones()
    {
        foreach (var boton in botones)
        {
            boton.interactable = true;
        }

        menuOpciones.SetActive(false);
    }
}
