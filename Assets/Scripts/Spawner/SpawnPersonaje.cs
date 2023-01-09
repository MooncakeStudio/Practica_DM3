using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPersonaje : MonoBehaviour
{

    [Header("Prefabs")]
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

    [Header("Componentes personaje")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button ataque;
    [SerializeField] private Button habilidad;

    [Header("Camara")]
    [SerializeField] private CinemachineVirtualCamera cameraVirtual;

    [Header("UI dependiente")]
    [SerializeField] private TextMeshProUGUI textoVida;
    [SerializeField] private Image vida;

    // Start is called before the first frame update
    void Start()
    {
        GameObject personaje = null;
        if (GameManager.eleccionPersonaje == Clase.LADRON)
        {
            personaje = Instantiate(prefabs[0],transform.position,Quaternion.identity);
            personaje.GetComponent<InputHandler>().SetComponentes(joystick, ataque, habilidad,15);
            personaje.GetComponent<VidaController>().Componentes(textoVida,vida);
            cameraVirtual.Follow = personaje.transform;
        }
        else if (GameManager.eleccionPersonaje == Clase.MAGO)
        {
            personaje = Instantiate(prefabs[1], transform.position, Quaternion.identity);
            personaje.GetComponent<InputHandler>().SetComponentes(joystick, ataque, habilidad,15);
            personaje.GetComponent<VidaController>().Componentes(textoVida, vida);
            cameraVirtual.Follow = personaje.transform;
        }
        else
        {
            personaje = Instantiate(prefabs[2], transform.position, Quaternion.identity);
            personaje.GetComponent<InputHandler>().SetComponentes(joystick, ataque, habilidad,15);
            personaje.GetComponent<VidaController>().Componentes(textoVida, vida);
            cameraVirtual.Follow = personaje.transform;
        }

        Destroy(gameObject);
    }
}
