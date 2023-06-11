using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaController : MonoBehaviour
{
    public float vidaMax = 0;
    public static float vida = 0;
    public Image bVida;
    [SerializeField] TextMeshProUGUI vidaNumero; 
    void Start(){
        vidaMax = gameObject.GetComponent<PersonajeController>().VidaTotal();
        vida = vidaMax;
        bVida = GameObject.Find("Canvas/BarraVida/Relleno Vida").GetComponent<Image>();
    }

    void Update()
    {
        if(bVida != null && vidaNumero != null) 
        {
            vida = Mathf.Clamp(vida, 0, vidaMax);
            bVida.fillAmount = vida / vidaMax;
            vidaNumero.text = (string)("" + (int)vida);
        }
        
    }

    public void actualizarVida(int vidaNueva){
        vida = vidaNueva;
        vida = Mathf.Clamp (vida, 0 ,vidaMax);
    }

    public void Componentes(TextMeshProUGUI vidaNumero, Image bVida)
    {
        this.vidaNumero = vidaNumero;
        this.bVida = bVida;
    }
}
