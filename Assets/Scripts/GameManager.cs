using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ATRIBUTOS

    private float tiempo;
    public static Clase eleccionPersonaje;
    public static GameManager instance;

    private int enemigosGenerar;
    private int enemigosGenerados;

    [Header("Pruebas")]
    [SerializeField] private int enemigosDerrotados;
    [SerializeField] private int ronda;
    [SerializeField] private int enemigosTotales;

    private bool nuevaRonda = true;

    private AudioSource asrc;

    // METODOS

    public void Awake()
    {
        asrc = gameObject.GetComponent<AudioSource>();

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
        ronda = 1;
        enemigosGenerar = 6;

        asrc.volume = 1;
    }

    private void Start()
    {
        PersonajeController.Muerto += FinPartida;
    }

    private void Update()
    {
        if(enemigosDerrotados == enemigosGenerar)
        {
            nuevaRonda = true;
            PasarRonda();
        }
    }

    

    public void PasarRonda() 
    { 
        ronda++;
        GameObject.Find("Canvas").transform.Find("HUD").transform.Find("RondasNum").GetComponent<TextMeshProUGUI>().text = "Ronda: " + ronda;
        //enemigosGenerar = enemigosGenerar + (int)Random.Range(1, 4);
        
        for(int i = 1; i < 4; i++)
        {
            var nuevosEnemigos = (int)Random.Range(0,2);
            var spawners = GameObject.Find("SP" + i);
            spawners.GetComponent<SpawnerManager>().AumentarEnemigosGenerar(nuevosEnemigos);
            enemigosGenerar += nuevosEnemigos;
        }
        enemigosDerrotados = 0; 
        enemigosGenerados = 0; 
    }
    public void NuevoEnemgio() { enemigosGenerados++; }
    public void EnemigoDerrotado() { enemigosDerrotados++; enemigosTotales++; }
    public int GetEnemigosGenerados() { return enemigosGenerados; }
    public int GetEnemigosGenerar() { return enemigosGenerar; }
    public int GetEnemigosTotalesDerrotados() { return enemigosTotales; }

    public int GetRonda() { return ronda; }
    public float GetTiempo() { return tiempo; }

    public bool DeberiaGenerarEnemgios() { return nuevaRonda; }
    public void EmpezadaRonda() { nuevaRonda = false; }
    public void AvanzaTiempo() { tiempo += Time.deltaTime; }

    public Clase GetEleccionPersonaje() { return eleccionPersonaje; }
    public void SetEleccionPersonaje(Clase nuevaEleccion) { eleccionPersonaje = nuevaEleccion; }

    public void FinPartida()
    {
        //DataHandler.instance.Guardar();
        ronda = 1;
        tiempo = 0;
        enemigosGenerar = 6;
        enemigosTotales = 0;
        enemigosGenerados = 0;


        StartCoroutine(MostrarFin());
    }

    public IEnumerator MostrarFin()
    {
        var canvas = GameObject.Find("Canvas").transform;

        var perdida = canvas.Find("Perdida");
        var joystick = canvas.Find("Botones/Fixed Joystick").gameObject;
        var ataque = canvas.Find("Botones/Botones Acciones/Ataque").gameObject;
        var habilidad = canvas.Find("Botones/Botones Acciones/Habilidad").gameObject;

        //joystick.GetComponent<FixedJoystick>().enabled = false;
        //ataque.GetComponent<Button>().interactable = false;
        //habilidad.GetComponent<Button>().interactable = false;
        //perdida.gameObject.SetActive(true);

        joystick.gameObject.SetActive(false);
        ataque.gameObject.SetActive(false);
        habilidad.gameObject.SetActive(false);
        perdida.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        //joystick.GetComponent<FixedJoystick>().enabled = true;
        //ataque.GetComponent<Button>().interactable = true;
        //habilidad.GetComponent<Button>().interactable = true;
        //perdida.gameObject.SetActive(false);

        joystick.gameObject.SetActive(true);
        ataque.gameObject.SetActive(true);
        habilidad.gameObject.SetActive(true);
        perdida.gameObject.SetActive(false);

        resetGame();
    }
    public void resetGame()
    {
        DataHandler.instance.Guardar();
        ronda = 1;
        tiempo = 0;
        enemigosGenerar = 5;
        enemigosTotales = 0;
        enemigosGenerados = 0;
        SceneManager.LoadScene("MenuPPal_Actualizado_ArregloInterfaz");
    }

    public IEnumerator playOnce(AudioClip clip)
    {
        asrc.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
    }

    public AudioSource GetAudioSource() { return asrc; }

    public void setClip(AudioClip clip)
    {
        if (clip.name != asrc.clip.name)
        {
            asrc.Stop();
            asrc.clip = clip;
            asrc.Play();
        }
    }

}


public enum Clase
{
    LADRON, MAGO, GUERRERO
}