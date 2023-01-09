using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconoManager : MonoBehaviour
{
    [SerializeField] Sprite ladron;
    [SerializeField] Sprite mago;
    [SerializeField] Sprite guerrero;

    public void Start()
    {
        var imagen = GetComponent<Image>();

        if(GameManager.eleccionPersonaje == Clase.LADRON)
        {
            imagen.sprite = ladron;
        } else if (GameManager.eleccionPersonaje == Clase.MAGO)
        {
            imagen.sprite = mago;
        } else
        {
            imagen.sprite = guerrero;
        }
    }
}
