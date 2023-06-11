using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    private int radius = 35;

    [Header("Prefab enemigo")]
    [SerializeField] private GameObject prefabEnemigo;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.DeberiaGenerarEnemgios())
        {
            GameManager.instance.EmpezadaRonda();
            StartCoroutine(generarEnemigos());
        }
    }

    IEnumerator generarEnemigos()
    {
        while(GameManager.instance.GetEnemigosGenerados() < GameManager.instance.GetEnemigosGenerar())
        {
            var tiempo = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(tiempo);
            GameManager.instance.NuevoEnemgio();
            Instantiate(prefabEnemigo,posicionPunto(),Quaternion.identity);
            
        }
    }

    private Vector3 posicionPunto()
    {
        Vector3 posicion = Vector3.zero;

        //f�rmula circunferencia conociendo centro y radio
        // (x -xc)^2 + (y+yc)^2 = r^2, siendo xc e yc los puntos del centro. El centro est� en (0,0) y el radio es 105.
        int xPos = Random.Range(-35, 0);
        
        //xPos = (int)Mathf.Pow(xPos, factoNegativo);

        float posX = Mathf.Pow(xPos, 2);
        float posZCuadrado = Mathf.Pow(radius, 2) - posX;
        if (posZCuadrado < 0) posZCuadrado = -posZCuadrado;
        float posZ = Mathf.Sqrt(posZCuadrado);
        int factoNegativo = Random.Range(1, 3);
        if (factoNegativo == 1)
            posZ = -posZ;

        posicion = new Vector3(xPos, 15.04f, posZ);
        return posicion;
    }
}
