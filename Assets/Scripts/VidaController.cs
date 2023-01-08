using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaController : MonoBehaviour
{
    public float vidaMax = 666;
    public float vida = 0;
    public Image bVida;

    void Start(){
        //pillar la vida del pj y poner en vidamax
    }

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp (vida, 0 ,vidaMax);
        bVida.fillAmount = vida / vidaMax;

    }
}
