using System.Collections;
using System.Collections.Generic;
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

        if(volumen > -80f)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
        } else
        {
            gameObject.GetComponent<Toggle>().isOn = false;
        }
    }

    public void CambiarVolumen(bool activo)
    {

        if (activo)
        {
            am.SetFloat("VolumenMaster", 0f);
        } else
        {
            am.SetFloat("VolumenMaster", -80f);
        }
        
    }
}
