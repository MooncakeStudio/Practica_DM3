using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MostrarPuntuaciones : MonoBehaviour
{
    [SerializeField] GameObject mostrarPuntuaciones;

    public void MostrarPuntuacion()
    {
        if (!mostrarPuntuaciones.gameObject.activeSelf)
        {

            mostrarPuntuaciones.gameObject.SetActive(true);

            SerializableScoreList scl = DataHandler.instance.CargarPuntuaciones();

            var texto = mostrarPuntuaciones.transform.Find("Modal/ListaHS/Container/Texto").GetComponent<TextMeshProUGUI>();

            var maximo = scl.list.Count < 10 ? scl.list.Count : 10;
            for (int i = 0; i < maximo; i++)
            {
                float minutos = Mathf.FloorToInt(scl.list[i].tiempo / 60);
                float segundos = Mathf.FloorToInt(scl.list[i].tiempo % 60);
                texto.text += scl.list[i].enemigosDerrotados + "\t\t" + scl.list[i].ronda + "\t\t" + string.Format("{0:0}:{1:00}", minutos, segundos) + "\n";
            }
        }
    }
}
