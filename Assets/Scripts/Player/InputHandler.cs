using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick joystick;

    [Header("Botones ataque")]
    [SerializeField] private Button ataque;
    [SerializeField] private Button habilidad;

    [Header("Parametros")]
    [SerializeField] private float Speed;

    private Rigidbody myRB;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //ataque.onClick.AddListener(Atacar);

        //Triggers para ataque
        var triggerAtaque = ataque.AddComponent<EventTrigger>();
        var ataqueDown = new EventTrigger.Entry();
        ataqueDown.eventID = EventTriggerType.PointerDown;
        ataqueDown.callback.AddListener((e) => Atacar());
        triggerAtaque.triggers.Add(ataqueDown);

        var ataqueUp = new EventTrigger.Entry();
        ataqueUp.eventID = EventTriggerType.PointerUp;
        ataqueUp.callback.AddListener((e) => Debug.Log("Ataque parando"));
        triggerAtaque.triggers.Add(ataqueUp);


        //Triggers para habilidad
        var triggerHabilidad = habilidad.AddComponent<EventTrigger>();
        var habilidadDown = new EventTrigger.Entry();
        habilidadDown.eventID = EventTriggerType.PointerDown;
        habilidadDown.callback.AddListener((e) => Habilidad());
        triggerHabilidad.triggers.Add(habilidadDown);

        var habilidadUp = new EventTrigger.Entry();
        habilidadUp.eventID = EventTriggerType.PointerUp;
        habilidadUp.callback.AddListener((e) => Debug.Log("Habilidad Parando"));
        triggerHabilidad.triggers.Add(habilidadUp);
        //habilidad.onClick.AddListener(Habilidad);
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector3(joystick.Horizontal*Speed, 0, joystick.Vertical * Speed);
    }

    void Atacar()
    {
        Debug.Log("Atacando");
    }

    void Habilidad()
    {
        Debug.Log("Habilidando");
    }
}
