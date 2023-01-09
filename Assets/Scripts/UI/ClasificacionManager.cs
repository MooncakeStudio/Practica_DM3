using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClasificacionManager : MonoBehaviour
{
    // Atributos

    [SerializeField] private GameObject scrollClasificacion;

    [SerializeField] private List<Button> botones;

    [SerializeField] private GameObject prefabScore;


    // METODOS

    public void AbrirClasificacion()
    {
        foreach (var boton in botones)
        {
            boton.interactable = false;
        }

        SerializableScoreList scl = GameManager.instance.GetComponent<DataHandler>().CargarPuntuaciones();

        var obj = Instantiate(prefabScore);

        foreach (SerializableScore sc in scl.list)
        {
            float minutos = Mathf.FloorToInt(sc.tiempo / 60);
            float segundos = Mathf.FloorToInt(sc.tiempo % 60);

            obj.GetComponent<TextMeshProUGUI>().text += sc.ronda + "\t \t \t" + string.Format("{0:0}:{1:00}", minutos, segundos);

            //scrollClasificacion.transform.Find("ViewPort").Find("Content")
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
