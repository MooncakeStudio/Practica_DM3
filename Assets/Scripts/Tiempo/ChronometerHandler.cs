using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChronometerHandler : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;

    // Update is called once per frame
    void Update()
    {
            GameManager.instance.AvanzaTiempo();

            muestraTiempo(GameManager.instance.GetTiempo());
    }

    void muestraTiempo(float tiempoAMostrar)
    {
        if (tiempoAMostrar < 0)
        {
            tiempoAMostrar = 0;
        }

        float minutos = Mathf.FloorToInt(tiempoAMostrar / 60);
        float segundos = Mathf.FloorToInt(tiempoAMostrar % 60);

        textoTiempo.text = string.Format("{0:0}:{1:00}", minutos, segundos);
    }
}
