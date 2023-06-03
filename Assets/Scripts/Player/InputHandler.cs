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
    private Animator animator;
    bool atacando = false;
    bool habilidadRecargada = true;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //ataque.onClick.AddListener(Atacar);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick != null)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                var toRotate = Quaternion.LookRotation(new Vector3(joystick.Horizontal, 0, joystick.Vertical), Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 360 * Time.deltaTime);
                animator.SetBool("Walking", true);

            }

            else
                animator.SetBool("Walking", false);
            myRB.velocity = new Vector3(joystick.Horizontal * Speed, 0, joystick.Vertical * Speed);
        }
        
    }

    public void Finataque()
    {
        atacando = false;
        animator.ResetTrigger("Atacar");
        animator.ResetTrigger("Especial");
    }

    void Atacar()
    {
        if (!atacando)
        {
            atacando = true;
            GetComponent<PersonajeController>().Atacar();
            animator.SetTrigger("Atacar");
        }
        
    }

    void Habilidad()
    {
        if (habilidadRecargada)
        {
            habilidadRecargada = false;
            GetComponent<PersonajeController>().AtacarEspecial();
            animator.SetTrigger("Especial");
            StartCoroutine(recargarHabilidad());
        }
        
    }

    public void SetComponentes(Joystick joystick, Button ataque, Button habilidad, float Speed)
    {
        this.joystick = joystick;
        this.ataque = ataque;
        this.habilidad = habilidad;

        //Triggers para ataque
        var triggerAtaque = this.ataque.AddComponent<EventTrigger>();
        var ataqueDown = new EventTrigger.Entry();
        ataqueDown.eventID = EventTriggerType.PointerDown;
        ataqueDown.callback.AddListener((e) => Atacar());
        triggerAtaque.triggers.Add(ataqueDown);

        var ataqueUp = new EventTrigger.Entry();
        ataqueUp.eventID = EventTriggerType.PointerUp;
        ataqueUp.callback.AddListener((e) => Debug.Log("Ataque parando"));
        triggerAtaque.triggers.Add(ataqueUp);


        //Triggers para habilidad
        var triggerHabilidad = this.habilidad.AddComponent<EventTrigger>();
        var habilidadDown = new EventTrigger.Entry();
        habilidadDown.eventID = EventTriggerType.PointerDown;
        habilidadDown.callback.AddListener((e) => Habilidad());
        triggerHabilidad.triggers.Add(habilidadDown);

        var habilidadUp = new EventTrigger.Entry();
        habilidadUp.eventID = EventTriggerType.PointerUp;
        habilidadUp.callback.AddListener((e) => Debug.Log("Habilidad Parando"));
        triggerHabilidad.triggers.Add(habilidadUp);
        //habilidad.onClick.AddListener(Habilidad);

        this.Speed = Speed;
    }

    public void changeCallback()
    {
        ataque.GetComponent<EventTrigger>().triggers.Clear();
        var ataqueDown = new EventTrigger.Entry();
        ataqueDown.eventID = EventTriggerType.PointerDown;
        ataqueDown.callback.AddListener((e) => GetComponent<MagoController>().Atacar());
        ataque.GetComponent<EventTrigger>().triggers.Add(ataqueDown);

        var ataqueUp = new EventTrigger.Entry();
        ataqueUp.eventID = EventTriggerType.PointerUp;
        ataqueUp.callback.AddListener((e) => Debug.Log("Ataque parando"));
        ataque.GetComponent<EventTrigger>().triggers.Add(ataqueUp);

        habilidad.GetComponent<EventTrigger>().triggers.Clear();
        var habilidadDown = new EventTrigger.Entry();
        habilidadDown.eventID = EventTriggerType.PointerDown;
        habilidadDown.callback.AddListener((e) => GetComponent<MagoController>().AtacarEspecial());
        habilidad.GetComponent<EventTrigger>().triggers.Add(habilidadDown);

        var habilidadUp = new EventTrigger.Entry();
        habilidadUp.eventID = EventTriggerType.PointerUp;
        habilidadUp.callback.AddListener((e) => GetComponent<MagoController>().FinAtacarEspecial());
        habilidad.GetComponent<EventTrigger>().triggers.Add(habilidadUp);

    }

    IEnumerator recargarHabilidad()
    {
        yield return new WaitForSeconds(GetComponent<PersonajeController>().GetTiempoRecarga());
        habilidadRecargada = true;
    }
}
