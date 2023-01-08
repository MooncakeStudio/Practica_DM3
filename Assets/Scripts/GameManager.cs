using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ATRIBUTOS

    public static float tiempo;
    public static int ronda;

    [SerializeField] TextMeshProUGUI mostrarPuntuaciones;

    // METODOS

    public void Awake()
    {
        tiempo = 0;
        ronda = 0;
    }

    public void MostrarPuntuaciones()
    {
        if (!mostrarPuntuaciones.gameObject.active)
        {

            mostrarPuntuaciones.gameObject.SetActive(true);

            SerializableScoreList scl = gameObject.GetComponent<DataHandler>().CargarPuntuaciones();

            var texto = mostrarPuntuaciones.GetComponent<TextMeshProUGUI>();

            foreach (SerializableScore sc in scl.list)
            {
                float minutos = Mathf.FloorToInt(sc.tiempo / 60);
                float segundos = Mathf.FloorToInt(sc.tiempo % 60);

                texto.text += sc.ronda + "\t \t \t" + string.Format("{0:0}:{1:00}", minutos, segundos) + "\n";
            }
        }
    }

    public void CerrarPuntuaciones()
    {
        var texto = mostrarPuntuaciones.GetComponent<TextMeshProUGUI>();
        texto.text = "";

        mostrarPuntuaciones.gameObject.SetActive(false);
    }
}
