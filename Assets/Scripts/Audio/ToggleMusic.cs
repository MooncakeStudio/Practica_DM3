using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    // ATRIBUTOS

    [SerializeField] private AudioMixer am;


    // METODOS

    public void Start()
    {
        am.GetFloat("VolumenMaster", out float volumen);
        if (gameObject.GetComponent<Toggle>() != null)
        {
            if (volumen > -80f)
            {
                gameObject.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                gameObject.GetComponent<Toggle>().isOn = false;
            }
        }
        else
        {
            Transform cuadroInfo = GameObject.Find("Canvas").transform.Find("Pause").transform.Find("Cuadro info");
            if (volumen > -80f) cuadroInfo.Find("Musica").gameObject.GetComponent<TextMeshProUGUI>().text = "Pausar sonido";
            else cuadroInfo.transform.Find("Musica").GetComponent<TextMeshProUGUI>().text = "Activar sonido";


        }
    }

    public void CambiarVolumen(bool activo)
    {

        if (activo)
        {
            am.SetFloat("VolumenMaster", 0f);
        }
        else
        {
            am.SetFloat("VolumenMaster", -80f);
        }

    }

    public void CambiarVolumenInGame()
    {
        float vol;
        am.GetFloat("VolumenMaster", out vol);

        Transform cuadroInfo = GameObject.Find("Canvas").transform.Find("Pause").transform.Find("Cuadro info");

        if (vol > -80f)
        {
            cuadroInfo.Find("Musica").gameObject.GetComponent<TextMeshProUGUI>().text = "Activar sonido";
            am.SetFloat("VolumenMaster", -80f);

        }
        else
        {
            cuadroInfo.transform.Find("Musica").GetComponent<TextMeshProUGUI>().text = "Pausar sonido";
            am.SetFloat("VolumenMaster", -0f);
        }
    }
}
