using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ATRIBUTOS

    private float tiempo;
    public static Clase eleccionPersonaje;
    public static GameManager instance;
    

    /*[Header("Texto puntuaciones")]
    [SerializeField] TextMeshProUGUI mostrarPuntuaciones;*/

    private int enemigosGenerar;
    private int enemigosGenerados;

    [Header("Pruebas")]
    [SerializeField] private int enemigosDerrotados;
    [SerializeField] private int ronda;

    private bool nuevaRonda = true;


    // METODOS

    public void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        tiempo = 0;
        ronda = 0;
        enemigosGenerar = 5;
        eleccionPersonaje = 0;
    }

    private void Update()
    {
        if(enemigosDerrotados == enemigosGenerar)
        {
            nuevaRonda = true;
            PasarRonda();
        }
    }

    /*public void MostrarPuntuaciones()
    {
        if (!mostrarPuntuaciones.gameObject.activeSelf)
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
    }*/

    /*public void CerrarPuntuaciones()
    {
        var texto = mostrarPuntuaciones.GetComponent<TextMeshProUGUI>();
        texto.text = "";

        mostrarPuntuaciones.gameObject.SetActive(false);
    }*/

    public void PasarRonda() { ronda++; enemigosGenerar = enemigosGenerar + (int)Random.Range(1, 4); enemigosDerrotados = 0; enemigosGenerados = 0; }
    public void NuevoEnemgio() { enemigosGenerados++; }
    public void EnemigoDerrotado() { enemigosDerrotados++; }
    public int GetEnemigosGenerados() { return enemigosGenerados; }
    public int GetEnemigosGenerar() { return enemigosGenerar; }

    public int GetRonda() { return ronda; }
    public float GetTiempo() { return tiempo; }

    public bool DeberiaGenerarEnemgios() { return nuevaRonda; }
    public void EmpezadaRonda() { nuevaRonda = false; }
    public void AvanzaTiempo() { tiempo += Time.deltaTime; }

    public Clase GetEleccionPersonaje() { return eleccionPersonaje; }
    public void SetEleccionPersonaje(Clase nuevaEleccion) { eleccionPersonaje = nuevaEleccion; }
}


public enum Clase
{
    LADRON, MAGO, GUERRERO
}