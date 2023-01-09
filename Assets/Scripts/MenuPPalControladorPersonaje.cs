using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPPalControladorPersonaje : MonoBehaviour
{
    //cambiar por lo que este estatico luego en game manager
    public int personaje = 0;
    private Vector3 vectorReset = new Vector3(-73.1f, 65.6f, 61f);
    private Vector3 vectorPos = new Vector3(0.6f, 14.7f, 61f);
    [SerializeField] GameObject ladron;
    [SerializeField] GameObject mago;
    [SerializeField] GameObject guerrero;
    // Start is called before the first frame update
    void Start()
    {
        ladron.transform.position = vectorReset;
        mago.transform.position = vectorReset;
        guerrero.transform.position = vectorReset;

        if(personaje == 0)
        {
            ladron.transform.position = vectorPos;
        } else if (personaje == 1)
        {
            mago.transform.position = vectorPos;
        } else
        {
            guerrero.transform.position = vectorPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
